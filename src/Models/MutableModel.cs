using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Common.Models
{
    /// <summary>
    /// Model implementing <see cref="INotifyPropertyChanged"/> with 
    /// a NotifyPropertyChanged method.
    /// </summary>
    public class MutableModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Method to call when a property changes.
        /// </summary>
        /// <param name="propertyName">Name of property that changed.</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}