using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAChallengeWebServices.Repository
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        void Insert(T item);
        void Delete(int id);
        void Modify(int id, T item);
    }
}
