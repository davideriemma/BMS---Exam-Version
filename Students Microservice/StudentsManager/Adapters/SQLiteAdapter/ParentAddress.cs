using System;
using System.Collections.Generic;

namespace StudentManager.Adapters.SQLiteAdapter
{
    public partial class ParentAddress
    {
        public long RelationId { get; set; }
        public string ParentId { get; set; } = null!;
        public long AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual Parent Parent { get; set; } = null!;
    }
}
