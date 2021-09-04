using System;

namespace Common.Models
{
    /// <summary>
    /// Model of type BaseModel with the Key/Id as a <see cref="string"/>
    /// </summary>
    [Obsolete]
    public class RootModel : BaseModel<string>
    {
        /// <summary>
        /// Instanciates a new <see cref="RootModel"/> with the 
        /// Id set to a new random number
        /// </summary>
        public RootModel() :base()
        {
            Id = Constants.random.Next().ToString();
        }
        /// <summary>
        /// Date when this model was last edited.
        /// </summary>
        public DateTime? LastModified { get; set; }
    }
}