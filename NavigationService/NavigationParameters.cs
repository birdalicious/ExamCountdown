using NavigationHelper.Exceptions;

namespace NavigationHelper
{
    public class NavigationParameters
    {
        private Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public T GetValue<T>(string key)
            where T : class
        {
            if (!_dictionary.TryGetValue(key, out var value))
            {
                throw new NavigationParameterDoesNotExistException();
            }

            if(value is T castValue)
            {
                return castValue;
            }

            throw new NavigationParameterTypeDoesNotMatchException();
        }

        public bool TryGetValue<T >(string key, ref T? value)
            where T: class
        {
            if (!_dictionary.TryGetValue(key, out var objValue))
            {
                return false;
            }

            value = objValue as T;

            return value is not null;
        }

        public void Add<T>(string key, T value)
            where T : class
        {
            if(value is null)
            {
                return;
            }

            _dictionary.Add(key, value);
        }
    }
}