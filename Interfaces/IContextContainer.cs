namespace MoviesAPI.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IContextContainer : IDisposable
    {
        Context Entities { get; }
        int SaveChanges();
    }
}
