using Lib.Models;
using Lib.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Services
{
    public class UserService : IUserService
    {
        private LibContext _context;
        public UserService(LibContext context)
        {
            _context = context;
        }


       

        /// <summary>
        /// get user details by user id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public User GetUser(int UserId)
        {
            User user;
            try
            {
                user = _context.Find<User>(UserId);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }




        /// <summary>
        /// get user details by user id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetUser(string name)
        {
            User user;
            try
            {
                user = _context.Find<User>(name);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }





        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public ResponseModel PutUser([FromBody] User user)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = GetUser(user.UserId);
                if (_temp != null)
                {
                    _temp.UserId = user.UserId;
                    _temp.UserName = user.UserName;
                    _context.Update<User>(_temp);
                    model.Messsage = "User Update Successfully";
                }
                else
                {
                    _context.Add<User>(user);
                    model.Messsage = "User Inserted Successfully";
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
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public ResponseModel DeleteUser(int UserId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = GetUser(UserId);
                if (_temp != null)
                {
                    _context.Remove<User>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "User Not Found";
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
