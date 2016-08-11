using System;
using System.Collections.Generic;

namespace BAChallengeWebServices.Repository
{

    /// <summary>
    /// interface of type <see cref="T"/> used by repositories that methods used by controllers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IGetableById<T>, IDisposable
    {
        /// <summary>
        /// Method that returns <see cref="List{T}"/> containing all items from needed database table
        /// </summary>
        /// <returns><see cref="List{T}"/></returns>
        IList<T> GetAll();
        /// <summary>
        /// Method that takes <see cref="T"/> items and inserts it into needed database table
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if insertion was successful and False if not/></returns>
        bool Insert(T item);
        /// <summary>
        /// Method that takes item id and deletes the item with the given id from a database table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if deletion was successful and False if not</returns>
        bool Delete(int id);
        /// <summary>
        /// Method that takes id and item of type <see cref="T"/> and replaces the item of given id (if such item exists) 
        /// with the given item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>True if modification was successful and False if not</returns>
        bool Modify(int id, T item);
    }
}
