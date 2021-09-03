using System;

namespace Common.Models
{
    /// <summary>
    /// Model with a custom type or Key for the Id.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    [Obsolete]
    public class BaseModel<TKey>
    {
        /// <summary>
        /// Instanciates a new model setting the <see cref="Timestamp"/>
        /// to <see cref="DateTime.Now"/>
        /// </summary>
        public BaseModel()
        {
            Timestamp = DateTime.Now;
        }
        /// <summary>
        /// Id of the model
        /// </summary>
        public TKey Id { get; set; }
        /// <summary>
        /// Date of creation for this model.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}