using System;

namespace DuoVia.Http
{
    public abstract class Channel : IDisposable
    {
        protected Type _serviceType;

        /// <summary>
        /// Invokes the method with the specified parameters.
        /// </summary>
        /// <param name="parameters">Parameters for the method call</param>
        /// <returns>An array of objects containing the return value (index 0) and the parameters used to call
        /// the method, including any marked as "ref" or "out"</returns>
        protected abstract object[] InvokeMethod(params object[] parameters);

        /// <summary>
        /// Channel must implement an interface synchronization method.
        /// This method asks the server for a list of identifiers paired with method
        /// names and -parameter types. This is used when invoking methods server side.
        /// </summary>
        protected abstract void SyncInterface(Type serviceType);

        #region IDisposable Members

        protected bool _disposed = false;

        public void Dispose()
        {
            //MS recommended dispose pattern - prevents GC from disposing again
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);

        #endregion
    }
}
