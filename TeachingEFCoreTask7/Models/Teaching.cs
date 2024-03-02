using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftStage2Tasks.TeachingEFCoreTask7.Models
{
    public class Teaching
    {
        [ForeignKey(nameof(Pupil))]
        public int PupilId { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }

        // navigation properties
        public Pupil Pupil { get; set; }
        public Teacher Teacher { get; set; }
    }
}
