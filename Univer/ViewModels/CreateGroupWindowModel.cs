using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;
using Univer.Commands;
using Univer.Models.Entities;

namespace Univer.ViewModels
{
    class CreateGroupWindowModel : BaseViewModel
    {
        private readonly Group _Group;

        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                OnProperyChanged();
            }
        }

        private readonly ICommand _SaveChangesCommand;
        public ICommand SaveChangesCommand { get => _SaveChangesCommand; }

        private void SaveChanges(object p)
        {
            App.CurrentWindow.DialogResult = true;
            //App.CurrentWindow.Close();
        }

        private bool CanSaveChangesExecute(object p) => true;

        public CreateGroupWindowModel(Group group)
        {
            _Group = group;
            _Name = _Group.Name;

            _SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChangesExecute);
        }
    }
}
