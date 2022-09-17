using System;
using System.Collections.Generic;
using Nootes.Models;

namespace Nootes.Stores
{
    public interface ISubjectsStore
    {
        public IEnumerable<Subject> Subjects { get; }

        public event Action SubjectsChanged;
        
        public void Initialize();

        public void AddSubject(Subject subject);

        public void DropSubject(Subject subject);
    }
}
