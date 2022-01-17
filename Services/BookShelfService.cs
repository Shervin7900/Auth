using Lib.Models;
using Lib.ViewModels;
using System.Web.Http;

namespace Lib.Services
{
    public class BookShelfService : IBookshelfService
    {
        private LibContext _context;
        public BookShelfService(LibContext context)
        {
            _context = context;
        }




        /// <summary>
        /// get bookshelf details by bookshelf id
        /// </summary>
        /// <param name="BookshelfId"></param>
        /// <returns></returns>
        public BookShelf GetBookShelf(int BookshelfId)
        {
            BookShelf bookshelf;
            try
            {
                bookshelf = _context.Find<BookShelf>(BookshelfId);
            }
            catch (Exception)
            {
                throw;
            }
            return bookshelf;
        }

        /// <summary>
        /// get bookshelf details by bookshelf id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BookShelf GetBookShelf(string name)
        {
            BookShelf bookshelf;
            try
            {
                bookshelf = _context.Find<BookShelf>(name);
            }
            catch (Exception)
            {
                throw;
            }
            return bookshelf;
        }




        /// <summary>
        ///  add edit bookshelf
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        public ResponseModel PutBookShelf([FromBody] BookShelf bookshelf)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                BookShelf _temp = GetBookShelf(bookshelf.Id);
                if (_temp != null)
                {
                    _temp.Id = bookshelf.Id;
                    _temp.Name = bookshelf.Name;
                    _context.Update<BookShelf>(_temp);
                    model.Messsage = "Bookshelf Update Successfully";
                }
                else
                {
                    _context.Add<BookShelf>(bookshelf);
                    model.Messsage = "Bookshelf Inserted Successfully";
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
        /// delete bookshelf
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public ResponseModel DeleteBookShelf(int bookshelfId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                BookShelf _temp = GetBookShelf(bookshelfId);
                if (_temp != null)
                {
                    _context.Remove<BookShelf>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Bookshelf Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Bookshelf Not Found";
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
