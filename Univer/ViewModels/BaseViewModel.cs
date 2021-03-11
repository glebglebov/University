using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Univer.ViewModels
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        private string _Title = "Default Title";
        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnProperyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperyChanged([CallerMemberName] string property = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
