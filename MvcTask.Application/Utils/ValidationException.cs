namespace MvcTask.Application.Utils
{
    using System;

    public class ValidationException : Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop)
            : base(message)
        {
            this.Property = prop;
        }
    }
}
