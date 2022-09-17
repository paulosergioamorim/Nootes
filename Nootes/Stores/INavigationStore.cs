using System;
using Nootes.ViewModels;

namespace Nootes.Stores
{
    public interface INavigationStore
    {
        public ViewModelBase CurrentViewModel { get; set; }

        public event Action NavigationChanged;
    }
}
