using System.Threading.Tasks;

namespace Nootes.Commands
{
    public abstract class AsyncCommand : CommandBase
    {
        private bool _disposed;

        private bool Disposed
        {
            get => _disposed;
            set
            {
                _disposed = value;
                OnCanExecuteChanged();
            }
        }

        protected abstract Task ExecuteAsync(object? parameter);

        public override bool CanExecute(object? parameter) => Disposed;

        public override async void Execute(object? parameter)
        {
            Disposed = false;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                Disposed = true;
            }
        }
    }
}
