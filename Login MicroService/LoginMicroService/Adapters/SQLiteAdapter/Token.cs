using System;
using System.Collections.Generic;

namespace LoginMicroService.Model
{
    public partial class Token
    {
        public string Token1 { get; set; } = null!;
        public string Username { get; set; } = null!;

        public virtual Login UsernameNavigation { get; set; } = null!;
    }
}
