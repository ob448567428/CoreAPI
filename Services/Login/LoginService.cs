using Entities;
using Services.Login.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Login
{
    public class LoginService : ILoginService
    {
        public Tuple<bool, UserInfoOutput> Login(LoginInput input)
        {
            var output = new UserInfoOutput();
            var tulpe = new Tuple<bool, UserInfoOutput>(true, output);
            return tulpe;
        }
    }
}
