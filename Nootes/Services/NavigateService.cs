using System;
using Nootes.Stores;
using Nootes.ViewModels;

namespace Nootes.Services
{
    public class NavigateService<TViewModel> : INavigateService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly INavigationStore _navigationStore;
        private readonly Func<TViewModel> _viewModelFactory;
        
        public NavigateService(INavigationStore navigationStore, Func<TViewModel> viewModelFactory)
        {
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
        }

        public void Navigate() => _navigationStore.CurrentViewModel = _viewModelFactory();
    }
}
