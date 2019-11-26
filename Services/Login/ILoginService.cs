using Services.Login.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Login
{
    public interface ILoginService 
    {
        Tuple<bool, UserInfoOutput> Login(LoginInput input);
    }
}
