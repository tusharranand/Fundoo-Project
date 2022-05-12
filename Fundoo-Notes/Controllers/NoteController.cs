﻿using Business_Layer.Interfaces;
using Common_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Entities;
using Repository_Layer.FundooContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoo_Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        FundooDbContext fundoo;
        INoteBL noteBL;

        public NoteController(FundooDbContext fundoo, INoteBL noteBL)
        {
            this.fundoo = fundoo;
            this.noteBL = noteBL;
        }

        [Authorize]
        [HttpPost("AddNote")]
        public async Task<ActionResult> AddNote(NotePostModel note)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                await this.noteBL.AddNote(UserId, note);
                return this.Ok(new { success = true, message = "Note Added Successfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpDelete("RemoveNote/{NoteID}")]
        public async Task<ActionResult> DeleteNote(int NoteID)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserID = Int32.Parse(userid.Value);
                var note = fundoo.Note.FirstOrDefault(x => x.UserID == UserID && x.NoteID == NoteID);
                if (note == null)
                    return this.BadRequest(new { success = false, message = "Sorry! This note does not exist." });
                await this.noteBL.DeleteNote(UserID, NoteID);
                return this.Ok(new { success = true, message = "Note Removed Successfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}