using SweeftStage2Tasks.TeachingEFCoreTask7.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftStage2Tasks.TeachingEFCoreTask7.Models
{
    public class Teacher
    {
        public int Id { get; set; } // EF Core will automatically detect that it's an Id

        [StringLength(25)]
        public required string Name { get; set; }

        [StringLength(50)]
        public required string Surname { get; set; }
        public Gender Gender { get; set; } // Class Enum gender can be created, but there are only 2 values, so I'll leave it like this

        [StringLength(50)]
        public required string Subject { get; set; }

        public List<Teaching> Teachings { get; } = [];

    }
}
