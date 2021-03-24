using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;
using Univer.Commands;
using Univer.Models.Entities;

namespace Univer.ViewModels
{
    class GroupEditWindowModel : BaseViewModel
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

        public ICommand SaveChangesCommand { get; }

        private void SaveChanges(object p)
        {
            App.CurrentWindow.DialogResult = true;
        }

        private bool CanSaveChangesExecute(object p) => true;

        public GroupEditWindowModel(Group group)
        {
            Title = "Изменить группу";

            _Group = group;
            _Name = _Group.Name;

            SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveChangesExecute);
        }
    }
}
