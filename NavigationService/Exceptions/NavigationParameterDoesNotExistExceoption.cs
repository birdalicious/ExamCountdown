using System.Runtime.Serialization;

namespace NavigationHelper.Exceptions
{
    [Serializable]
    internal class NavigationParameterDoesNotExistExceoption : Exception
    {
        public NavigationParameterDoesNotExistExceoption()
        {
        }

        public NavigationParameterDoesNotExistExceoption(string? message) : base(message)
        {
        }

        public NavigationParameterDoesNotExistExceoption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NavigationParameterDoesNotExistExceoption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}