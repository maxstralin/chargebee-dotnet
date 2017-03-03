using System;
using System.Collections.Generic;
using System.Text;

namespace ChargeBee
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class DescriptionAttribute : Attribute
    {
        readonly string _description;

        public DescriptionAttribute(string description)
        {
            _description = description;
        }

        public string Description
        {
            get { return _description; }
        }
    }
}
