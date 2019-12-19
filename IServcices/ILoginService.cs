using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices
{
    public interface ILoginService 
    {
        Tuple<bool, UserInfoOutput> Login(LoginInput input);
    }
}
