using System.Runtime.Serialization;

namespace NavigationHelper.Exceptions
{
    [Serializable]
    internal class NavigationParameterDoesNotExistException : Exception
    {
        public NavigationParameterDoesNotExistException()
        {
        }

        public NavigationParameterDoesNotExistException(string? message) : base(message)
        {
        }

        public NavigationParameterDoesNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NavigationParameterDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}