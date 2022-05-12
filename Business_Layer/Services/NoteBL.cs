﻿using Business_Layer.Interfaces;
using Common_Layer;
using Repository_Layer.Entities;
using Repository_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }
        public async Task AddNote(int UserID, NotePostModel note)
        {
            try
            {
                await this.noteRL.AddNote(UserID, note);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}