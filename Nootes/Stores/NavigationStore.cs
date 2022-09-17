using System;
using Nootes.ViewModels;

namespace Nootes.Stores
{
    public class NavigationStore : INavigationStore
    {
        private ViewModelBase _currentViewModel = null!;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnNavigationChanged();
            }
        }

        public event Action? NavigationChanged;

        private void OnNavigationChanged() => NavigationChanged?.Invoke();
    }
}
