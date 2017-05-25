using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JTTT.Annotations;

namespace JTTT.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName] => Validate();

        protected virtual string Validate()
        {
            return String.Empty;
        }

        public string Error { get; }
    }
}
