using Lib.Models;
using Lib.ViewModels;
using System.Web.Http;

namespace Lib.Services
{
    public class ShelfService : IShelfService
    {
        private LibContext _context;
        public ShelfService(LibContext context)
        {
            _context = context;
        }




        /// <summary>
        /// get book details bybook id
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        public Shelf GetShelf(int shelfId)
        {
            Shelf shelf;
            try
            {
                shelf = _context.Find<Shelf>(shelfId);
            }
            catch (Exception)
            {
                throw;
            }
            return shelf;
        }


        /// <summary>
        /// get book details bybook id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Shelf GetShelf(string name)
        {
            Shelf shelf;
            try
            {
                shelf = _context.Find<Shelf>(name);
            }
            catch (Exception)
            {
                throw;
            }
            return shelf;
        }

        /// <summary>
        ///  add edit book
        /// </summary>
        /// <param name="shelfModel"></param>
        /// <returns></returns>
        public ResponseModel PutShelf([FromBody] Shelf shelf)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Shelf _temp = GetShelf(shelf.shelfId);
                if (_temp != null)
                {
                    _temp.shelfId = shelf.shelfId;
                    _temp.shelfName = shelf.shelfName;
                    _context.Update<Shelf>(_temp);
                    model.Messsage = "Shelf Update Successfully";
                }
                else
                {
                    _context.Add<Shelf>(shelf);
                    model.Messsage = "Shelf Inserted Successfully";
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
        /// <param name="shelfId"></param>
        /// <returns></returns>
        public ResponseModel DeleteShelf(int shelfId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Shelf _temp = GetShelf(shelfId);
                if (_temp != null)
                {
                    _context.Remove<Shelf>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Shelf Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Shelf Not Found";
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
