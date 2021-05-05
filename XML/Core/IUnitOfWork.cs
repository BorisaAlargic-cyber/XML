using System;
namespace XML.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
