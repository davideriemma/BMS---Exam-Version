using System;
using System.Collections.Generic;

namespace LoginMicroService.Model
{
    public partial class Key
    {
        public long Id { get; set; }
        public string Private { get; set; } = null!;
        public string Public { get; set; } = null!;
    }
}
