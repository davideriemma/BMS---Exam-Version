using System;
using System.Collections.Generic;

namespace StudentManager.Adapters.SQLiteAdapter
{
    public partial class Address
    {
        public Address()
        {
            ParentAddresses = new HashSet<ParentAddress>();
            StudentAddresses = new HashSet<StudentAddress>();
        }

        public long InternalAddressId { get; set; }
        public string? Street { get; set; }
        public string City { get; set; } = null!;
        public long? ZipCode { get; set; }
        public string Provincia { get; set; } = null!;

        public virtual ICollection<ParentAddress> ParentAddresses { get; set; }
        public virtual ICollection<StudentAddress> StudentAddresses { get; set; }
    }
}
