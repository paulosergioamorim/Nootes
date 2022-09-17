using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nootes.Models;

namespace Nootes.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly string _filePath;

        public SubjectService(string filePath) => _filePath = filePath;

        public IEnumerable<Subject> GetSubjects()
        {
            try
            {
                return File.ReadAllLines(_filePath).Select(l => (Subject) l);
            }
            catch
            {
                return Enumerable.Empty<Subject>();
            }
        }

        public bool AddSubject(Subject subject)
        {
            try
            {
                File.AppendAllLines(_filePath, new[] { (string) subject }, Encoding.UTF8);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DropSubject(Subject subject)
        {
            List<Subject> subjects = GetSubjects().ToList();

            bool success = subjects.Remove(subject);

            if (!success)
                return false;

            File.WriteAllLines(_filePath, subjects.Select(s => (string) s));

            return true;
        }

        public bool UpdateSubject(Subject updated)
        {
            List<Subject> subjects = GetSubjects().ToList();

            Subject? existed = subjects.Find(s => s.Title == updated.Title);

            if (existed is null)
                return false;

            existed.Teacher = updated.Teacher;
            existed.Note = updated.Note;

            try
            {
                File.WriteAllLines(_filePath, subjects.Select(s => (string) s));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
