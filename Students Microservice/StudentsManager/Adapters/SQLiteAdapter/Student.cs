using System;
using System.Collections.Generic;

namespace StudentManager.Adapters.SQLiteAdapter
{
    public partial class Student
    {
        public Student()
        {
            StudentAddresses = new HashSet<StudentAddress>();
        }

        public string Cf { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public long TelephoneNumber { get; set; }

        public virtual Parent Parent { get; set; } = null!;
        public virtual ICollection<StudentAddress> StudentAddresses { get; set; }
    }
}
