using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.App
{
    public interface IAuthHelper
    {
        void Signin(AuthViewModel account);
        void SignOut();
        bool IsAuthenticated();
    }
}
