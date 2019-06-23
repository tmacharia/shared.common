using System;
using System.Reflection;

namespace Common
{
    /// <summary>
    /// Represents the base interface that classes that have a disposable object
    /// should inherit from since it executes safe disposition and suppression.
    /// </summary>
    public abstract class IBaseInterface : IDisposable
    {
        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        /// <summary>
        /// Deconstructor.
        /// </summary>
        ~IBaseInterface()
        {
            Dispose(false);
        }
        /// <summary>
        /// Dispose method. 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Dispose method that can be overriden by the inheriting class.
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing)
        {

        }
        /// <summary>
        /// Calls the default dispose method on a object
        /// </summary>
        /// <param name="item">Item to dispose.</param>
        public void DisposeItem<TItem>(ref TItem item)
        {
            if (item != null)
            {
                MethodInfo method = null;
#if NETSTANDARD1_5 || NETSTANDARD1_6
                method = item.GetType().GetRuntimeMethod("Dispose",null);
#else
                method = item.GetType().GetMethod("Dispose");
#endif
                if (method.IsNotNull())
                {
                    method.Invoke(item, null);
                    item = default(TItem);
                }
            }
        }
    }
}