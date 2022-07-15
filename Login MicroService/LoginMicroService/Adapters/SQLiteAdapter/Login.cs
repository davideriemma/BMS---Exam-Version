using System;
using System.Collections.Generic;

namespace LoginMicroService.Model
{
    public partial class Login
    {
        public string Username { get; set; } = null!;
        public string Hashed { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual Token Token { get; set; } = null!;
    }
}
