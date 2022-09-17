using Nootes.Models;

namespace Nootes.ViewModels
{
    public class SubjectViewModel
    {
        private readonly Subject _subject;

        public SubjectViewModel(Subject subject) => _subject = subject;

        public string Title => _subject.Title;

        public string Teacher => _subject.Teacher;

        public double Note => _subject.Note;

        public string IsApproved => Note >= 60 ? "Yes" : "No";
    }
}
