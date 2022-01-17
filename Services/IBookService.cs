using Lib.Models;
using Lib.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Services
{
    public interface IBookService
    {

        /// <summary>
        /// get list of all books by id
        /// </summary>
        /// <returns></returns>
        Book GetBook(int id);

        /// <summary>
        /// get bookdetails by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Book GetBook(string name);

        /// <summary>
        ///  add edit book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        ResponseModel PutBook([FromBody] Book book);


        /// <summary>
        /// delete book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseModel DeleteBook(int id);

    }  }


