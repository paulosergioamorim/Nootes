using System.ComponentModel;
using Nootes.Models;
using Nootes.Services;
using Nootes.Stores;
using Nootes.ViewModels;

namespace Nootes.Commands
{
    public class AddSubjectCommand : CommandBase
    {
        private readonly AddSubjectViewModel _addSubjectViewModel;
        private readonly ISubjectsStore _subjectsStore;
        private readonly INavigateService<HomeViewModel> _navigateService;

        public AddSubjectCommand(AddSubjectViewModel addSubjectViewModel,
                                 ISubjectsStore subjectsStore,
                                 INavigateService<HomeViewModel> navigateService)
        {
            _addSubjectViewModel = addSubjectViewModel;
            _subjectsStore = subjectsStore;
            _navigateService = navigateService;
            _addSubjectViewModel.PropertyChanged += AddSubjectViewModelChanged;
            OnCanExecuteChanged();
        }

        private string Title => _addSubjectViewModel.Title;

        private string Teacher => _addSubjectViewModel.Teacher;

        private string Note => _addSubjectViewModel.Note;

        private void AddSubjectViewModelChanged(object? sender,
                                                PropertyChangedEventArgs e)
        {
            if (e.PropertyName is nameof(ErrorViewModel.HasErrors))
                OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter) => !_addSubjectViewModel.HasErrors
                                                           && Title != string.Empty
                                                           && Teacher != string.Empty
                                                           && Note != string.Empty;

        public override void Execute(object? parameter)
        {
            Subject subject = new Subject(Title, Teacher, double.Parse(Note));
            _subjectsStore.AddSubject(subject);

            _addSubjectViewModel.Title = string.Empty;
            _addSubjectViewModel.Teacher = string.Empty;
            _addSubjectViewModel.Note = string.Empty;

            _navigateService.Navigate();
        }
    }
}
