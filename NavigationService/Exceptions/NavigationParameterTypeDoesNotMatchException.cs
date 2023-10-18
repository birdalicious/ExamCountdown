using System.Runtime.Serialization;

namespace NavigationHelper.Exceptions
{
    [Serializable]
    internal class NavigationParameterTypeDoesNotMatchException : Exception
    {
        public NavigationParameterTypeDoesNotMatchException()
        {
        }

        public NavigationParameterTypeDoesNotMatchException(string? message) : base(message)
        {
        }

        public NavigationParameterTypeDoesNotMatchException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NavigationParameterTypeDoesNotMatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}