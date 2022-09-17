using System;
using System.Linq;
using System.Windows.Input;
using Nootes.Commands;
using Nootes.Services;
using Nootes.Stores;

namespace Nootes.ViewModels
{
    public class AddSubjectViewModel : ErrorViewModel
    {
        private readonly ISubjectsStore _subjectsStore;

        private string _teacher = string.Empty;
        private string _title = string.Empty;
        private string _note = string.Empty;

        public AddSubjectViewModel(INavigateService<HomeViewModel> navigateService,
                                   ISubjectsStore subjectsStore)
        {
            _subjectsStore = subjectsStore;
            CancelCommand = new NavigateCommand<HomeViewModel>(navigateService);
            SubmitCommand = new AddSubjectCommand(this, subjectsStore, navigateService);
        }
        
        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();

                ClearErrors();

                if (_subjectsStore.Subjects.Any(s =>
                        string.Equals(s.Title, Title, StringComparison.CurrentCultureIgnoreCase)))
                    AddError("This subject has been added!");
            }
        }

        public string Teacher
        {
            get => _teacher;
            set
            {
                _teacher = value;
                OnPropertyChanged();
            }
        }

        public string Note
        {
            get => _note;
            set
            {
                _note = value;
                OnPropertyChanged();

                ClearErrors();

                if (!double.TryParse(Note, out double note) && Note != string.Empty)
                    AddError("This value for note is invalid!");

                if (note is < 0 or > 100 && Note != string.Empty)
                    AddError("This number is out of range 0 to 100");
            }
        }
    }
}
