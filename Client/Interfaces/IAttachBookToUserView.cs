﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces
{
    public interface IAttachBookToUserView
    {
        void SetListBox(IEnumerable<User> collection);
    }
}