using Lib.Models;
using Lib.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Services
{
    public interface IShelfService
    {
        /// <summary>
        /// get list of all shelfs by id
        /// </summary>
        /// <returns></returns>
        Shelf GetShelf(int id);

        /// <summary>
        /// get shelf details by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Shelf GetShelf(string name);

        /// <summary>
        ///  add edit shelf
        /// </summary>
        /// <param name="shelf"></param>
        /// <returns></returns>
        ResponseModel PutShelf([FromBody] Shelf shelf);


        /// <summary>
        /// delete shelf
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseModel DeleteShelf(int id);

    }
}

