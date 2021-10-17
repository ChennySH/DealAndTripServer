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
    [Route("api/[controller]")]
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
    }
}
