using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationHelper
{
    internal class NavigationStack
    {
        private List<(string, NavigationParameters)> _stack = new();

        public bool HasElements => _stack.Count > 0;

        public void Add(string uri, NavigationParameters parameters)
        {
            _stack.Add((uri, parameters));
        }

        public string PreviousUri()
        {
            return _stack.Last().Item1;
        }

        public NavigationParameters PreviousNavigationParameters()
        {
            return _stack.Last().Item2;
        }

        public (string uri, NavigationParameters parameters) Pop()
        {
            var value = _stack.Last();
            _stack.RemoveAt(_stack.Count - 1);
            return value;
        }
    }
}
