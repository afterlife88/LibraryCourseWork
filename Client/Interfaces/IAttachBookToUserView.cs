using System;
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
        void SetUsers(IEnumerable<User> collection);
        void SetBooks(IEnumerable<Book> collection);
        void SetUsersThatHaveBook(IEnumerable<User> collection);
    }
}
