using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Nootes.ViewModels
{
    public class ErrorViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors;

        protected ErrorViewModel() => _errors = new Dictionary<string, List<string>>();

        public IEnumerable GetErrors(string? propertyName) =>
            _errors.GetValueOrDefault(propertyName!, new List<string>());

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        protected void AddError(string errorMessage,
                                [CallerMemberName] string? propertyName = default)
        {
            if (_errors.ContainsKey(propertyName!))
                _errors[propertyName!].Add(errorMessage);
            else
                _errors.Add(propertyName!, new List<string> { errorMessage });

            OnErrorsChanged(propertyName);
        }

        protected void ClearErrors([CallerMemberName] string? propertyName = default)
        {
            _errors.Remove(propertyName!);

            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string? propertyName = default)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
        }
    }
}
