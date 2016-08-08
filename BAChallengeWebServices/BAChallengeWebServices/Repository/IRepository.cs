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
        bool Insert(T item);
        bool Delete(int id);
        bool Modifiy(int id, T item);
    }
}
