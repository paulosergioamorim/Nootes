using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Nootes.Commands;
using Nootes.Services;
using Nootes.Stores;

namespace Nootes.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ISubjectsStore _subjectsStore;
        
        public HomeViewModel(ISubjectsStore subjectsStore,
                             INavigateService<AddSubjectViewModel> navigateService)
        {
            _subjectsStore = subjectsStore;
            _subjectsStore.SubjectsChanged += SubjectsChanged;
            _subjectsStore.Initialize();
            AddSubjectCommand = new NavigateCommand<AddSubjectViewModel>(navigateService);
            DropSubjectCommand = new DropSubjectCommand(_subjectsStore);
        }

        private void SubjectsChanged() => OnPropertyChanged(nameof(Subjects));

        public IEnumerable<SubjectViewModel> Subjects => _subjectsStore.Subjects.Select(s => new SubjectViewModel(s));
        
        public ICommand AddSubjectCommand { get; }

        public ICommand DropSubjectCommand { get; }
    }
}
