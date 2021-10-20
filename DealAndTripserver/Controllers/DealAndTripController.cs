using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Add the below
using DealAndTripServerBL.Models;
using System.IO;

namespace DealAndTripServer.Controllers
{
    [Route("api/TripsApi")]
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
        [HttpGet]
        public User GetUser([FromQuery] string userName, [FromQuery] string password)
        {
            User u = context.GetUser(userName, password);
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
        [Route("Sign Up")]
        [HttpGet]
    }
}
