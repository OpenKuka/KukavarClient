namespace OpenKuka.KRL.Data.Parser
{
    public class Token<T> where T : System.Enum
    {
        public T Type { get; protected set; }
        public bool Skip { get; protected set; }
        public virtual string Value { get; protected set; }

        public Token(T tokenType, bool skip = false)
        {
            Type = tokenType;
            Skip = skip;
        }

        public override string ToString()
        {
            return string.Format("Token<{0}> : '{1}'", Type, Value);
        }
    }
}
