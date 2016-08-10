using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAChallengeWebServices.Repository
{
    public interface IRepository<T> : IGetableById<T>, IDisposable
    {
        IList<T> GetAll();
        bool Insert(T item);
        bool Delete(int id);
        bool Modify(int id, T item);
    }
}
