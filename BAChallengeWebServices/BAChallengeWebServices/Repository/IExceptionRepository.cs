using System.Collections.Generic;

namespace BAChallengeWebServices.Repository
{
    /// <summary>
    /// An interface of type <see cref="T"/> used by repositories to return all caught errors
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IExceptionRepository<T>
    {
        /// <summary>
        /// Method that returns all caught errors
        /// </summary>
        /// <returns><see cref="List{T}"/> of all caught errors</returns>
        IList<T> GetAll();
    }
}