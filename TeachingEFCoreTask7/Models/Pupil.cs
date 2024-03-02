using SweeftStage2Tasks.TeachingEFCoreTask7.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftStage2Tasks.TeachingEFCoreTask7.Models
{
    public class Pupil
    {
        public int Id { get; set; }

        [StringLength(25)]
        public required string Name { get; set; }

        [StringLength(50)]
        public required string Surname { get; set; }
        public Gender Gender { get; set; }

        [Range(0, 25)]
        public int Class { get; set; }

        public List<Teaching> Teachings { get; } = [];
    }
}
