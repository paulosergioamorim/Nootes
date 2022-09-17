using Nootes.ViewModels;

namespace Nootes.Services
{
    public interface INavigateService<in TViewModel> where TViewModel : ViewModelBase
    {
        public void Navigate();
    }
}
