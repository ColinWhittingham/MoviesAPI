namespace MoviesAPI
{
    using MoviesAPI.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ContextContainer : IContextContainer
    {
        private bool _disposed = false;

        public Context Entities
        {
            get => new Context();
        }

        public int SaveChanges()
        {
            return Entities.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                Entities?.Dispose();
            }
            _disposed = true;
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}