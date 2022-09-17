using System.Collections.Generic;
using Nootes.Models;

namespace Nootes.Services
{
    public interface ISubjectService
    {
        public IEnumerable<Subject> GetSubjects();

        public bool AddSubject(Subject subject);

        public bool DropSubject(Subject subject);

        public bool UpdateSubject(Subject updated);
    }
}
