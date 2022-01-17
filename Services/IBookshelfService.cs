using Lib.Models;
using Lib.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Services
{
    public interface IBookshelfService
    {
        /// <summary>
        /// get list of all bookshelf by id
        /// </summary>
        /// <returns></returns>
        BookShelf GetBookShelf(int id);

        /// <summary>
        /// get bookshelf details by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        BookShelf GetBookShelf(string name);

        /// <summary>
        ///  add edit bookshelf 
        /// </summary>
        /// <param name="bookshelf"></param>
        /// <returns></returns>
        ResponseModel PutBookShelf([FromBody] BookShelf bookshelf);


        /// <summary>
        /// delete bookshelf
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseModel DeleteBookShelf(int id);
    }
}
