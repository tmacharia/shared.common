using System;

namespace Common.Attributes
{
    /// <summary>
    /// Specifies name & description of a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DisplayClassAttribute : Attribute
    {
        public DisplayClassAttribute(string name)
        {
            if (name.IsValid())
                Name = name;
        }
        public DisplayClassAttribute(string name,string description)
            :this(name)
        {
            if (description.IsValid())
                Description = description;
        }
        /// <summary>
        /// Value of name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value of description.
        /// </summary>
        public string Description { get; set; }
    }
}