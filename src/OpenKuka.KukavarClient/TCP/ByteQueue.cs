using NLog;
using System;
using System.Collections.Generic;

namespace OpenKuka.KukavarClient.TCP
{
    public class ByteQueue
    {
        #region Events

        /// <summary>
        /// Get notified when the buffer capacity has changed.
        /// </summary>
        public event EventHandler<CapacityEventArgs> CapacityChanged;
        public class CapacityEventArgs : EventArgs
        {
            public int PreviousCapacity { get; private set; }
            public int NewCapacity { get; private set; }
            public CapacityEventArgs(int previousCapacity, int newCapacity)
            {
                PreviousCapacity = previousCapacity;
                NewCapacity = newCapacity;
            }
        }
        private void OnCapacityChanged(int prevCapacity, int newCapacity)
        {
            Logger.Log(LogLevel.Debug, "[{0}] the capacity has changed from {1} bytes to {2} bytes.", Name, prevCapacity, newCapacity);
            CapacityChanged?.Invoke(this, new CapacityEventArgs(prevCapacity, newCapacity));
        }

        /// <summary>
        /// Get notified when the buffer is overflowed by a chunk of bytes.
        /// When the buffer is overflowed, new bytes are enqueued at the begining of the buffer, 
        /// thus discarding the oldest bytes in the buffer that have not yet been dequeued.
        /// This will lead to corruption in messages as it will break the coherence of the incoming stream.
        /// </summary>
        public event EventHandler<OverflowEventArgs> Overflow;
        public class OverflowEventArgs : EventArgs
        {
            /// <summary>
            /// The total length of the chunk of bytes that has overflowed the buffer when queued.
            /// This event appends after the chunk is queued and because the buffer's capacity has reached its maximum allowed size.
            /// </summary>
            public int BytesCount { get; private set; }

            /// <summary>
            /// The current buffer capacity which has been overflown by the last chunk of bytes enqueued.
            /// Normally, this should return the buffer's MaxCapacity.
            /// </summary>
            public int BufferCapacity { get; private set; }

            /// <summary>
            /// The number of bytes in the buffer just before the last chunk of bytes was enqueued and provoked the overflow.
            /// </summary>
            public int BufferCount { get; private set; }

            public OverflowEventArgs(int bytesCount, int bufferCount, int bufferCapacity)
            {
                BytesCount = bytesCount;
                BufferCount = bufferCount;
                BufferCapacity = bufferCapacity;
            }
        }
        private void OnOverflow(int bytesCount, int bufferCount, int bufferCapacity)
        {
            Overflow?.Invoke(this, new OverflowEventArgs(bytesCount, bufferCount, bufferCapacity));
        }

        /// <summary>
        /// This callback is invoked just before a chunk of bytes which does not fit in the buffer is going to be enqueued.
        /// Here, put the logic you want to prevent the overflow to happen (for instance increase the buffer's MaCapacity).
        /// </summary>
        public Action<ByteQueue, byte[], int, int> OverflowingCallback;

        #endregion

        #region Private

        private readonly object syncObj = new object();

        private int receivedCount;
        private int minCapacity;
        private int maxCapacity;

        /// <summary>
        /// The internal buffer.
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// The buffer index of the first byte to dequeue.
        /// </summary>
        private int head;

        /// <summary>
        /// The buffer index of the last byte to dequeue.
        /// </summary>
        private int tail = -1;

        /// <summary>
        /// Indicates whether the buffer is empty. The empty state cannot be distinguished from the
        /// full state with <see cref="head"/> and <see cref="tail"/> alone.
        /// </summary>
        private bool isEmpty = true;

        #endregion

        #region Properties

        public string Name { get; set; } = "ByteQueue";
        public Logger Logger { get; private set; }

        /// <summary>
        /// Gets a byte by byte enumeration of the buffer content, starting at head, ending at tail and of size Count.
        /// Must be consumed within a lock that prevent others to read from / write to the buffer until the object is disposed.
        /// Avoid array allocation.
        /// </summary>
        public IEnumerable<byte> Content
        {
            get
            {
                lock (syncObj)
                {
                    if (!isEmpty)
                    {
                        if (tail >= head)
                        {
                            for (int i = head; i <= tail; i++)
                            {
                                yield return buffer[i];
                            }
                        }
                        else
                        {
                            for (int i = head; i < Capacity; i++)
                            {
                                yield return buffer[i];
                            }
                            for (int i = 0; i <= tail; i++)
                            {
                                yield return buffer[i];
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The minimum capacity of the buffer.
        /// </summary>
        public int MinCapacity
        {
            get
            {
                lock (syncObj)
                {
                    return minCapacity;
                }
            }
            set
            {
                lock (syncObj)
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException("MinCapacity", "The MinCapacity must not be negative.");
                    if (value > MaxCapacity)
                        throw new ArgumentOutOfRangeException("MinCapacity", "The MinCapacity is greater than MaxCapacity.");
                    minCapacity = value;
                }
            }
        }

        /// <summary>
        /// The maximum capacity of the buffer.
        /// </summary>
        public int MaxCapacity
        {
            get
            {
                lock (syncObj)
                {
                    return maxCapacity;
                }
            }
            set
            {
                lock (syncObj)
                {
                    if (value < 0)
                    throw new ArgumentOutOfRangeException("MaxCapacity", "The MaxCapacity must not be negative.");
                if (value < MinCapacity)
                    throw new ArgumentOutOfRangeException("MaxCapacity", "The MaxCapacity is smaller than MinCapacity.");
                if (value < Count)
                    throw new ArgumentOutOfRangeException("MaxCapacity", "The MaxCapacity is smaller than Count.");
                maxCapacity = value;
                }
            }
        }

        /// <summary>
        /// Gets the capacity of the buffer.
        /// </summary>
        public int Capacity
        {
            get { lock (syncObj) { return buffer.Length; } }
        }

        /// <summary>
        /// Gets the number of bytes contained in the buffer.
        /// </summary>
        public int Count
        {
            get
            {
                lock (syncObj)
                {
                    if (isEmpty)
                    {
                        return 0;
                    }
                    else if (tail >= head)
                    {
                        return tail - head + 1;
                    }
                    else
                    {
                        return Capacity - head + tail + 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the number of unsued bytes  in the buffer.
        /// </summary>
        public int FreeCount
        {
            get { lock (syncObj) { return Capacity - Count; } }
        }

        public int ReceivedCount
        {
            get { lock (syncObj) { return receivedCount; } }
        }

        #endregion Properties

        #region Constructors

        public ByteQueue(string name, int initialCapacity = 256, int minCapacity = 256, int maxCapacity = 4096, Logger logger = null)
        {
            Logger = logger ?? NLog.LogManager.CreateNullLogger();

            Name = name;
            MaxCapacity = maxCapacity;
            MinCapacity = minCapacity;
            SetCapacity(initialCapacity);

            receivedCount = 0;

            Logger.Info("[{0}] byte buffer initialized with capacity : initial={1}, min={2}, max={3}", Name, Capacity, MinCapacity, MaxCapacity);
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Removes all bytes from the buffer.
        /// </summary>
        public void Clear()
        {
            lock (syncObj)
            {
                head = 0;
                tail = -1;
                isEmpty = true;
                //Reset(ref availableTcs);
            }
        }

        /// <summary>
        /// Sets the buffer capacity. Existing bytes are kept in the buffer.
        /// </summary>
        /// <param name="newCapacity">The new buffer capacity.</param>
        public bool SetCapacity(int newCapacity)
        {
            lock (syncObj)
            {
                if (newCapacity < 0)
                    throw new ArgumentOutOfRangeException(nameof(newCapacity), "The capacity must not be negative.");
                if (newCapacity < MinCapacity)
                    throw new ArgumentOutOfRangeException(nameof(newCapacity), "The capacity is smaller than the MinCapacity allowed.");
                if (newCapacity > MaxCapacity)
                    throw new ArgumentOutOfRangeException(nameof(newCapacity), "The capacity is greater than the MaxCapacity allowed.");
                if (newCapacity < Count)
                    throw new ArgumentOutOfRangeException(nameof(newCapacity), "The capacity is too small to hold the current buffer content.");

                if (buffer == null)
                {
                    buffer = new byte[newCapacity];
                }
                else
                {
                    int prevCapacity = Capacity;
                    if (newCapacity != Capacity)
                    {
                        var newBuffer = new byte[newCapacity];
                        int count = 0;
                        foreach (var b in Content)
                        {
                            newBuffer[count] = b;
                            count += 1;
                        }
                        buffer = newBuffer;
                        OnCapacityChanged(prevCapacity, newCapacity);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Sets the capacity to the actual number of bytes in the buffer, if that number is less
        /// than 90 percent of current capacity and superior tot the MinCapacity.
        /// </summary>
        public bool TrimExcess()
        {
            lock (syncObj)
            {
                if (Count < Capacity * 0.9 && Count >= MinCapacity)
                {
                    SetCapacity(Count);
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Adds bytes to the end of the buffer.
        /// </summary>
        /// <param name="chunk">The chunck to add to the buffer.</param>
        /// <param name="offset">The index in <paramref name="chunk"/> of the first byte to add.</param>
        /// <param name="count">The number of bytes to add.</param>
        public void Enqueue(byte[] chunk, int offset, int count)
        {
            Enqueue(chunk, offset, count, false);
        }
        private void Enqueue(byte[] chunk, int offset, int count, bool bypassOverflowing)
        {
            var overflowing = false;
            lock (syncObj)
            {
                //Debug.WriteLine("### Buffer : enqueue has lock ...");
                // preform some checks on input parameters
                if (chunk == null)
                    throw new ArgumentNullException(nameof(chunk), "The chunck is null.");
                if (offset < 0)
                    throw new ArgumentOutOfRangeException(nameof(offset), "Wrong offset. Must be greater or equal to zero.");
                if (count < 0)
                    throw new ArgumentOutOfRangeException(nameof(count), "Wrong count. Must be greater or equal to zero.");
                if (offset + count > chunk.Length)
                    throw new ArgumentOutOfRangeException(nameof(offset) + ", " + nameof(count), "Wrong (offest + count). Must not be greater than the chunck length.");
                if (count == 0)
                    return;

                // check if the chunck can fit in the buffer 
                // regarding the actual capacity and amount of free space
                var requiredCapacity = Count + count;

                // detect portential overflow
                overflowing = requiredCapacity > MaxCapacity ? true : false;
                if (!overflowing || bypassOverflowing)
                {
                    if (requiredCapacity > Capacity)
                    {
                        if (requiredCapacity > MaxCapacity)
                        {
                            // it's still an overflow

                            // notify that an overflow occured despite the call to OverflowingCallback
                            var ex = new OverflowException(string.Format("[{0}] buffer overflow : failed to enqueue {1} bytes. The buffer can only accept {2} more bytes.", Name, count, (MaxCapacity - Count)));
                            Logger.Log(LogLevel.Fatal, ex, ex.Message);
                            OnOverflow(count, Count, MaxCapacity);
                            // we throw an error as this would lead to corrupted data otherwise
                            throw ex;
                        }
                        else
                        {
                            // the buffer capactity can be extended to acccept the chunk
                            int q = (Capacity / 2) * 2;
                            while (q < requiredCapacity) q *= 2;    // extend capacity by power of 2
                            SetCapacity(Math.Min(MaxCapacity, q));  // but limited to MaxCapacity
                            overflowing = false;
                        }    
                    }

                    (int tailCount, int wrapCount) = FitChunk(count);

                    if (tailCount > 0)
                    {
                        Array.Copy(chunk, offset, buffer, tail + 1, tailCount);
                    }
                    if (wrapCount > 0)
                    {
                        Array.Copy(chunk, offset + tailCount, buffer, 0, wrapCount);
                    }
                    tail = (tail + count) % Capacity;
                    isEmpty = false;
                    Logger.Log(LogLevel.Trace, "[{0}] ++{1,3} bytes enqueued | count={2}", Name, count, Count);
                }
            }

            if (overflowing && !bypassOverflowing)
            {
                // try to do something to prevent overflow (outside the lock of Enqueue())
                lock (syncObj)
                {
                    Logger.Log(LogLevel.Warn, "[{0}] buffer overflow alert : could not enqueue {1} bytes. The buffer can only accept {2} more bytes.", Name, count, (MaxCapacity - Count));
                    OverflowingCallback?.Invoke(this, chunk, count, offset);
                }

                // retry to enqueue the chunk of bytes but this time bypass the overflow check
                Enqueue(chunk, offset, count, true);
            }
        }

        public int Dequeue(int count)
        {
            lock (syncObj)
            {
                if (count < 0)
                    throw new ArgumentOutOfRangeException(nameof(count), "The count must not be negative.");
                if (count == 0)
                    return 0;

                count = count > Count ? Count : count;
                if (count == Count)
                {
                    isEmpty = true;
                    head = 0;
                    tail = -1;
                }
                else
                {
                    head = (head + count) % Capacity;
                }
                Logger.Log(LogLevel.Trace, "[{0}] --{1,3} bytes dequeued | count={2}", Name, count, Count);
                return count;
            }         
        }
        public int Dequeue(int count, ref byte[] buffer)
        {
            lock (syncObj)
            {
                if (count < 0)
                    throw new ArgumentOutOfRangeException(nameof(count), "The count must not be negative.");
                if (count == 0)
                    return 0;

                count = Math.Min(Math.Min(count, Count), buffer.Length);

                int i = 0;
                foreach (var item in Content)
                {
                    buffer[i++] = item;
                    if (i == count) break;
                }

                if (count == Count)
                {
                    isEmpty = true;
                    head = 0;
                    tail = -1;
                }
                else
                {
                    head = (head + count) % Capacity;
                }
                Logger.Log(LogLevel.Trace, "[{0}] --{1,3} bytes dequeued | count={2}", Name, count, Count);
                return count;
            }
        } 

        /// <summary>
        /// How a certain chunk of data fits in the buffer.
        /// Results are reliable only if the chunck can effectively fit in the buffer (FreeBytesCount >= chunck.Length).
        /// </summary>
        /// <param name="chunkCount">The number of bytes to enqueue in the buffer.</param>
        /// <returns>
        /// TailspanCount : the length of the tailspan
        /// WrapspanCount : the length of the (possibile) wrapspan
        /// </returns>
        private (int TailspanCount, int WrapspanCount)  FitChunk(int chunkCount)
        {
            lock (syncObj)
            {
                int tailspanCount;
                int wrapspanCount;
                if (tail >= head || isEmpty)
                {
                    // free space between tail and end of buffer : (Capacity - 1) - (tail + 1) + 1
                    tailspanCount = Math.Min(Capacity - 1 - tail, chunkCount);

                    // possibly remainder to be wrapped at the begining of the buffer (if possible)
                    wrapspanCount = chunkCount - tailspanCount;
                }
                else // 0 <= tail < head
                {
                    // (head - 1) - (tail + 1) + 1 : free space between tail and head
                    tailspanCount = Math.Min(head - 1 - tail, chunkCount);
                    wrapspanCount = 0;
                }
                return (tailspanCount, wrapspanCount);
            }
        }

        #endregion
    }
}
