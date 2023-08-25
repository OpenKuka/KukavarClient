using System;
using System.Collections.Generic;
using System.Text;

namespace Krl.Types
{
    public enum MODE_OP
    {
        /// <summary>
        /// Test 1.
        /// </summary>
        T1,

        /// <summary>
        /// Test 2.
        /// </summary>
        T2,

        /// <summary>
        /// Automatic.
        /// </summary>
        AUT,

        /// <summary>
        /// Automatic External.
        /// </summary>
        EX
    }

    public enum PRO_STATE
    {
        /// <summary>
        /// Program not selected.
        /// </summary>
        P_FREE,

        /// <summary>
        /// Program reset.
        /// </summary>
        P_RESET,

        /// <summary>
        /// Program active
        /// </summary>
        P_ACTIVE,

        /// <summary>
        /// Program stopped.
        /// </summary>
        P_STOP,

        /// <summary>
        /// End of program reached
        /// </summary>
        P_END
    }

    public enum PRO_MODE
    {
        /// <summary>
        /// IncrementalStep : lock-by-blockprocessing with a stop after each instruction (without advance run processing).
        /// </summary>
        ISTEP,

        /// <summary>
        /// Program Step: Complete processing of subprograms (without advance run processing).
        /// </summary>
        PSTEP,

        /// <summary>
        /// Motion Step: Step-by-step processing with a stop after each motion instruction (without advance run processing).
        /// </summary>
        MSTEP,

        /// <summary>
        /// Continuous Step: Step-by-step processing with a stop after each motion instruction (with advance run processing).
        /// </summary>
        CSTEP,

        /// <summary>
        /// Continuous execution to the end of the program.
        /// </summary>
        GO,

        /// <summary>
        /// Continuous execution backwards to the start of the program.
        /// </summary>
        BSTEP
    }

    public enum ASYNC_STATE
    {
        /// <summary>
        /// Asynchronous motions active, stopped or temporarily stored.
        /// </summary>
        BUSY,

        /// <summary>
        /// No asynchronous motions active or stopped (queue is empty); last motion terminated without an interrupt.
        /// </summary>
        IDLE,

        /// <summary>
        /// No asynchronous motions active or stopped (queue is empty); last motion was canceled.
        /// </summary>
        CANCELLED,

        /// <summary>
        /// Asynchronous motion is planned, but is not currently being executed
        /// </summary>
        PEND
    }

    public enum AXBOX
    {
        /// <summary>
        /// Work envelope monitoring deactivated
        /// </summary>
        OFF,

        /// <summary>
        /// The output is set if the TCP is located inside the work envelope.
        /// </summary>
        INSIDE,

        /// <summary>
        /// The output is set if the TCP is located outside the work envelope
        /// </summary>
        OUTSIDE,

        /// <summary>
        /// The output is set and the robot stopped if the TCP is located inside the work envelope
        /// </summary>
        INSIDE_STOP,

        /// <summary>
        /// The output is set and the robot stopped if the TCP is located outside the work envelope
        /// </summary>
        OUTSIDE_STOP
    }

    public enum SIG_STATE
    {
        /// <summary>
        /// No enabling switch pressed (default position) or switched fully pressed (panic position).
        /// </summary>
        RELEASED,

        /// <summary>
        /// One or more enabling switches pressed (enabling position).
        /// </summary>
        PRESSED
    }
}

