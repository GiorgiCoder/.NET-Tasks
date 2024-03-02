using Microsoft.EntityFrameworkCore;
using SweeftStage2Tasks.TeachingEFCoreTask7.Data;
using SweeftStage2Tasks.TeachingEFCoreTask7.Data.Enums;
using SweeftStage2Tasks.TeachingEFCoreTask7.Interfaces;
using SweeftStage2Tasks.TeachingEFCoreTask7.Models;

namespace SweeftStage2Tasks.TeachingEFCoreTask7.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyDbContext _context;

        public TeacherRepository(MyDbContext context)
        {
            _context = context;
        }

        // I wrote 4 methods, ordered by mostly used or efficient to less. 
        public Teacher[] GetAllTeachersByStudent(string studentName)
        {
            // 1st approach. Using seperate query to select teacherIds who teach the student. Uses only 1 include
            var teachingIdsForPupil = _context.Teachings
                .Include(t => t.Pupil)
                .Where(p => p.Pupil.Name == studentName)
                .Select(x => x.TeacherId)
                .ToList();

            var teachers1 = _context.Teachers
                .Where(t => teachingIdsForPupil.Contains(t.Id))
                .ToArray();

            // 2nd approach. Using includes to eagerly load teaching and pupil tables (2 includes)
            var teachers2 = _context.Teachers
                .Include(t => t.Teachings)
                .ThenInclude(tg => tg.Pupil)
                .Where(t => t.Teachings.Any(teaching => teaching.Pupil.Name == studentName))
                .ToArray();

            // 3rd approach. Using navigation properties if we always update them and they are never null
            var teachers3 = _context.Teachers
                .Where(t => t.Teachings.Any(teaching => teaching.Pupil.Name == studentName))
                .ToArray();

            // 4th approach. Using joins as in SQL query from task 6.2
            var pupilsNamedName = _context.Pupils.Where(p => p.Name == studentName);
            var teachers4 = from pupil in pupilsNamedName
                            join teaching in _context.Teachings on pupil.Id equals teaching.PupilId
                            join teacher in _context.Teachers on teaching.TeacherId equals teacher.Id
                            select teacher;

            return teachers1;
        }
    }
}
