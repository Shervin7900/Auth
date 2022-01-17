using Lib.Models;
using Lib.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace Lib.Services
{
    public class BookService : IBookService
    {
            private LibContext _context;
            public BookService(LibContext context)
            {
                _context = context;
            }




            /// <summary>
            /// get book details bybook id
            /// </summary>
            /// <param name="bookId"></param>
            /// <returns></returns>
            public Book GetBook(int BookId)
            {
                Book book;
                try
                {
                    book =_context.Find<Book>(BookId);
                }
                catch (Exception)
                {
                    throw;
                }
                return book;
            }



        /// <summary>
        /// get book details bybook name
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public Book GetBook(string bookName)
        {
            Book book;
            try
            {
                book = _context.Find<Book>(bookName);
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }





        /// <summary>
        ///  add edit book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public ResponseModel PutBook([System.Web.Http.FromBody] Book book)
            {
                ResponseModel model = new ResponseModel();
                try
                {
                    Book _temp = GetBook(book.Id);
                    if (_temp != null)
                    {
                        _temp.Id = book.Id;
                        _temp.bookName = book.bookName;
                        _context.Update<Book>(_temp);
                        model.Messsage = "Book Update Successfully";
                    }
                    else
                    {
                        _context.Add<Book>(book);
                        model.Messsage = "Book Inserted Successfully";
                    }
                    _context.SaveChanges();
                    model.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    model.IsSuccess = false;
                    model.Messsage = "Error : " + ex.Message;
                }
                return model;
            }

            /// <summary>
            /// delete employees
            /// </summary>
            /// <param name="bookId"></param>
            /// <returns></returns>
            public ResponseModel DeleteBook(int bookId)
            {
                ResponseModel model = new ResponseModel();
                try
                {
                    Book _temp = GetBook(bookId);
                    if (_temp != null)
                    {
                        _context.Remove<Book>(_temp);
                        _context.SaveChanges();
                        model.IsSuccess = true;
                        model.Messsage = "Book Deleted Successfully";
                    }
                    else
                    {
                        model.IsSuccess = false;
                        model.Messsage = "Book Not Found";
                    }
                }
                catch (Exception ex)
                {
                    model.IsSuccess = false;
                    model.Messsage = "Error : " + ex.Message;
                }
                return model;
            }

           }
    }
    

