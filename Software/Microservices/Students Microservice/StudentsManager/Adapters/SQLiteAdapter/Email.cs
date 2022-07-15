using System;
using System.Collections.Generic;

namespace StudentManager.Adapters.SQLiteAdapter
{
    public partial class Email
    {
        public string StudentCf { get; set; } = null!;
        public string Email1 { get; set; } = null!;

        public virtual Student StudentCfNavigation { get; set; } = null!;
    }
}
