using System;

namespace ToolBox.Common.Exceptions
{
    public class ToolBoxException : Exception
    {
        public string Code { get; }

        public ToolBoxException()
        {
        }

        public ToolBoxException(string code)
        {
            Code = code;
        }

        public ToolBoxException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public ToolBoxException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public ToolBoxException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public ToolBoxException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}