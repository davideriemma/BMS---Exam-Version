using System;
using System.Collections.Generic;

namespace StudentManager.Adapters.SQLiteAdapter
{
    public partial class Parent
    {
        public Parent()
        {
            ParentAddresses = new HashSet<ParentAddress>();
        }

        public string Cf { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string? StudentId { get; set; }

        public virtual Student CfNavigation { get; set; } = null!;
        public virtual ICollection<ParentAddress> ParentAddresses { get; set; }
    }
}
