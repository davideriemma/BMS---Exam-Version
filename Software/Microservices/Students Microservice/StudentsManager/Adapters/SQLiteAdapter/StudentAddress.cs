using System;
using System.Collections.Generic;

namespace StudentManager.Adapters.SQLiteAdapter
{
    public partial class StudentAddress
    {
        public long RelationId { get; set; }
        public long AddressId { get; set; }
        public string StudentId { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
