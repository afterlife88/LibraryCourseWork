using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    public interface IPasswordProperty
    {
        string GetPassword();
        void SetPassword(string pass);
    }
}
