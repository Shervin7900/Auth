using Lib.Models;
using Lib.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Services
{
    public interface IUserService
    {
        /// <summary>
        /// get list of all users by id
        /// </summary>
        /// <returns></returns>
        User GetUser(int id);

        /// <summary>
        /// get user details by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        User GetUser(string name);

        /// <summary>
        ///  add edit user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ResponseModel PutUser([FromBody] User user);


        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        ResponseModel DeleteUser(int id);
    }
}
