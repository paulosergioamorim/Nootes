using Nootes.Models;
using Nootes.Stores;
using Nootes.ViewModels;

namespace Nootes.Commands
{
    public class DropSubjectCommand : CommandBase
    {
        private readonly ISubjectsStore _subjectsStore;

        public DropSubjectCommand(ISubjectsStore subjectsStore) => _subjectsStore = subjectsStore;

        public override void Execute(object? parameter)
        {
            if (parameter is not SubjectViewModel selectedSubject)
                return;

            Subject subject = new Subject(selectedSubject.Title, selectedSubject.Teacher, selectedSubject.Note);
            _subjectsStore.DropSubject(subject);
        }
    }
}
