using System.Collections.Generic;
using System.Linq;

namespace Common.Models
{
    /// <summary>
    /// Represents an object with details of update changes between two
    /// models/entities.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class UpdateResult<TModel> where TModel : class
    {
        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public UpdateResult()
        {
            PropertyUpdates = new List<PropertyUpdateResult>();
        }
        /// <summary>
        /// Base Model.
        /// </summary>
        public TModel BaseModel { get; set; }
        /// <summary>
        /// Updated Model.
        /// </summary>
        public TModel UpdatedModel { get; set; }
        /// <summary>
        /// Collection of each property update results.
        /// </summary>
        public virtual ICollection<PropertyUpdateResult> PropertyUpdates { get; set; }
        /// <summary>
        /// Gets a collection of each individual changes as string
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetChangesAsString()
        {
            if (PropertyUpdates == null)
                PropertyUpdates = new List<PropertyUpdateResult>();
            return PropertyUpdates.Select(x => x.ToString());
        }
    }
}