namespace BAChallengeWebServices.Repository
{
    /// <summary>
    /// Interface that implements a method, used by repositories, that returns element by id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGetableById<out T>
    {
        /// <summary>
        /// Method that returns element of type <see cref="T"></see> that has an id of given parameter 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);
    }
}