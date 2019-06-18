using System;
using System.Collections.Generic;

namespace Common.Models
{
    /// <summary>
    /// Represents a boxed object to safely return the end result of a function 
    /// execution and carries a generic type.
    /// </summary>
    /// <typeparam name="T">Type of data it holds.</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Result()
        {
            Errors = new List<Exception>();
        }
        /// <summary>
        /// Checks if the result was returned with any errors or not.
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return Errors.Count < 1;
            }
        }
        /// <summary>
        /// Additional message to pass back in case execution succeeded. This can also 
        /// hold an error message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data object
        /// </summary>
        public T Model { get; set; }
        /// <summary>
        /// List of exceptions caught during execution.
        /// </summary>
        public List<Exception> Errors { get; set; }
    }
}