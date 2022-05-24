using CSVApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApplication.Core.Interfaces
{
    public interface IUser
    {
        public UserModel Login(UserLoginModel login);
        public UserModel Get(UserLoginModel login);
    }
}
