using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Add the below
using DealAndTripServerBL.Models;
using DealAndTripServer.DTO;
using System.IO;


namespace DealAndTripServer.Controllers
{
    [Route("DealAndTripAPI")]
    [ApiController]
    public class DealAndTripController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        DealAndTripDBContext context;
        public DealAndTripController(DealAndTripDBContext context)
        {
            this.context = context;
        }
        #endregion


        [Route("Hello")]
        [HttpGet]
        public string HelloWorld()
        {
            return "hello cheni";
        }
        [Route("Login")]
        [HttpPost]
        public User Login([FromBody] LoginDTO loginDTO)
        {
            string userNameOrEmail = loginDTO.UserNameOrEmail;
            string password = loginDTO.Password;
            User u = context.GetUser(userNameOrEmail, password);
            //Check user name and password
            if (u != null)
            {
                HttpContext.Session.SetObject("theUser", u);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                return u;
            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
        [Route("SignUp")]
        [HttpPost]

        public bool SignUp([FromBody] User user)
        {
            bool isExist = this.context.IsExist(user.UserName, user.Email); 
            if (isExist)
                return false;
            else
            {
                this.context.Users.Add(user);
                this.context.SaveChanges();
                return true;
            }
        }
        [Route("IsUserNameExist")]
        [HttpPost]
        public bool IsUserNameExist([FromBody] string userName)
        {
            return this.context.IsUserNameExist(userName);
        }
        [Route("IsEmailExist")]
        [HttpPost]
        public bool IsEmailExist([FromBody] string userName)
        {
            return this.context.IsEmailExist(userName);
        }
    }
}
