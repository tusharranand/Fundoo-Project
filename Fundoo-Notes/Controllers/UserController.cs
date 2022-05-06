﻿using Common_Layer.Users;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.FundooContext;
using Repository_Layer.Interfaces;
using System;

namespace Fundoo_Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        FundooDbContext fundoo;
        IUserBL userBL;
        public UserController(FundooDbContext fundoo, IUserBL userBL)
        {
            this.fundoo = fundoo;
            this.userBL = userBL;
        }
        [HttpPost("AddUser")]
        public ActionResult AddUser(UserPostModel user)
        {
            try
            {
                this.userBL.AddUser(user);
                return this.Ok(new { success = true, message = $"User Added Successfully" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = $"Registration Fail {e.Message}" });
            }        
        }
    }
}