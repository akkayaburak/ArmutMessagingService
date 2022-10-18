using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public class RegisterCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}