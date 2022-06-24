using Microsoft.AspNetCore.Mvc;
using BookStore.Models.NewFolder1;
using BookStore.Repository;
using BookStore.Api;
using BookStore.Models.ViewModels;
using System.Net;
using System;
namespace BookStore.Api.Controllers

{
    [Route("api/public")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        UserRepository _repository = new UserRepository();

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                User user = _repository.Login(model);
                if (User == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(),"User not found");
                return StatusCode(HttpStatusCode.OK.GetHashCode(),user);
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),ex.Message);
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                User user = _repository.Register(model);
                if (User == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "User not found");
                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }
    }
}
