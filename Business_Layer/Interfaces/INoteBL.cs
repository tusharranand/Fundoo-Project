﻿using Common_Layer;
using Repository_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Interfaces
{
    public interface INoteBL
    {
        Task AddNote(int UserID, NotePostModel note);
    }
}