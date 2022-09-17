using Nootes.Stores;

namespace Nootes.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationStore _navigationStore;

        public MainViewModel(INavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.NavigationChanged += NavigationChanged;
        }

        private void NavigationChanged() => OnPropertyChanged(nameof(CurrentViewModel));

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
