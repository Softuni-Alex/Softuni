namespace CustomORM.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the operations we can perform with the db
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Insert/Update data 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Persist(object entity);

        /// <summary>
        /// Return entity object of type T by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById<T>(int id);

        /// <summary>
        /// Returns collection of entities of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> FindAll<T>();

        /// <summary>
        /// Returns collection of entities of type T matching the "where" criteria
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<T> FindAll<T>(string where);

        /// <summary>
        /// Returns the first entity of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T FindFirst<T>();

        /// <summary>
        /// Returns the first entity of type T matching the "where" criteria
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        T FindFirst<T>(string where);
    }
}