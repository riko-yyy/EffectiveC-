using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class Callback
    {
        private string _name;

        public Callback(string name)
        {
            _name = name;
        }

        public Callback Method1(Func<bool> predicate)
        {
            if (predicate())
            {
                return new Callback(_name);
            }

            return new Callback("");
        }

    }
}
