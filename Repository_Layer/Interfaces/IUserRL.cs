﻿using Common_Layer.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Interfaces
{
    public interface IUserRL
    {
        public void AddUser(UserPostModel user);
    }
}
