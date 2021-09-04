using System;
using System.Extensions;

namespace Common.Attributes
{
    /// <summary>
    /// Specifies name &amp; description of a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DisplayClassAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public DisplayClassAttribute(string name)
        {
            if (name.IsValid())
                Name = name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
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