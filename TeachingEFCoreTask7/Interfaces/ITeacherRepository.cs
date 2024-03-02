using SweeftStage2Tasks.TeachingEFCoreTask7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftStage2Tasks.TeachingEFCoreTask7.Interfaces
{
    public interface ITeacherRepository
    {
        public Teacher[] GetAllTeachersByStudent(string studentName);
    }
}
