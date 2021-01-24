using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth
{
    public class NameRequirement :IAuthorizationRequirement
    {
        public string NameToAccessAction { get; }

    public NameRequirement(string name)
    {
            NameToAccessAction = name;
    }

    }
}

