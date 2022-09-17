using System;
using System.Collections.Generic;
using Nootes.Models;
using Nootes.Services;

namespace Nootes.Stores
{
    public class SubjectsStore : ISubjectsStore
    {
        private readonly List<Subject> _subjects;
        private readonly ISubjectService _subjectService;

        public SubjectsStore(ISubjectService subjectService)
        {
            _subjects = new List<Subject>();
            _subjectService = subjectService;
        }

        public IEnumerable<Subject> Subjects => _subjects;

        public event Action? SubjectsChanged;

        public void Initialize()
        {
            IEnumerable<Subject> subjects = _subjectService.GetSubjects();
            _subjects.AddRange(subjects);
            OnSubjectsChanged();
        }

        public void AddSubject(Subject subject)
        {
            _subjectService.AddSubject(subject);
            _subjects.Add(subject);
            OnSubjectsChanged();
        }

        public void DropSubject(Subject subject)
        {
            _subjectService.DropSubject(subject);
            _subjects.Remove(subject);
            OnSubjectsChanged();
        }

        private void OnSubjectsChanged() => SubjectsChanged?.Invoke();
    }
}
