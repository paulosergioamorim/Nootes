using Nootes.ViewModels;

namespace Nootes.Services
{
    public delegate void Navigator<in TViewModel>() where TViewModel : ViewModelBase;
}
