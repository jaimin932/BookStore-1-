using Microsoft.AspNetCore.Mvc;
using BookStore.Repository;
using  BookStore.Models.NewFolder1;
using BookStore.Models.ViewModels;
using System.Net;
using System;
namespace BookStore.Api.Controllers

{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository _repository = new UserRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetUsers(int pageIndex=1,int pagesize =10,string keyword="")
        {
            try
            {
                var users = _repository.GetUsers(pageIndex, pagesize, keyword);
                if (users == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
                return StatusCode(HttpStatusCode.OK.GetHashCode(), users);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
            
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUsers(int id)
        {
            try
            {
                var users = _repository.GetUsers(id);
                if (users == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
                return StatusCode(HttpStatusCode.OK.GetHashCode(), users);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }

        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateUser(User model)
        {
            try
            {
                if(model != null)
                {
                    var users = _repository.GetUsers(model.Id);
                    if (users == null)
                        return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");

                    users.FirstName = model.FirstName;
                    users.LastName = model.LastName;
                    users.Email = model.Email;
                    var isSaved = _repository.UpdateUser(model);
                    if(isSaved)
                    {
                        return StatusCode(HttpStatusCode.OK.GetHashCode(), "User updated successfully");
                    }
                }
                return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (id > 0)
                {
                    var users = _repository.GetUsers(id);
                    if (users == null)
                        return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");

                   
                    var isDeleted = _repository.DeleteUser(users);
                    if (isDeleted)
                    {
                        return StatusCode(HttpStatusCode.OK.GetHashCode(), "User deleted successfully");
                    }
                }
                return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }


    }
}
