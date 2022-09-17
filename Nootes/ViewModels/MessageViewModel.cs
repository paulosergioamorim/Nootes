using System.Text;

namespace Nootes.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        private string _message = string.Empty;

        public string Message
        {
            get => _message;
            set
            {
                _message = value; 
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        public MessageViewModel()
        {
        }
        
        public MessageViewModel(string message) => Message = message;

        public bool HasMessage => Message != string.Empty;
    }
}
