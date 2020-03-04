using System.Text;

namespace Common.Models
{
    /// <summary>
    /// Represents an individual value property change on a model.
    /// </summary>
    public class PropertyUpdateResult
    {
        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public PropertyUpdateResult()
        { }
        /// <summary>
        /// Instanciates property update result object.
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <param name="oldValue">Base/old property value</param>
        /// <param name="newValue">New/updated property value.</param>
        public PropertyUpdateResult(string propertyName, object oldValue, object newValue)
        {
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
        }
        /// <summary>
        /// Property Name.
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Value of property in base/old model.
        /// </summary>
        public object OldValue { get; set; }
        /// <summary>
        /// Value of property in new/updated model.
        /// </summary>
        public object NewValue { get; set; }
        /// <summary>
        /// Rate of change as a percentage.
        /// </summary>
        public double PercentageChange { get; set; }
        /// <summary>
        /// Checks whether the new property value is not equal
        /// to the old property value.
        /// </summary>
        public bool HasChanges => !NewValue.Equals(OldValue);

        /// <summary>
        /// Returns a string that represents the property change.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{PropertyName}: ");
            if (!HasChanges)
                sb.Append("No Changes.");
            else
            {
                sb.Append("From ");
                string old = OldValue != null ? OldValue.ToString() : "Null";
                string current = NewValue != null ? NewValue.ToString() : "Null";
                sb.Append($"({old}) to ({current})");
            }
            return sb.ToString().Trim();
        }
    }
}