using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Univer.Interfaces;
using Univer.Views;
using Univer.ViewModels;
using Univer.Models.Entities;

namespace Univer.Models
{
    class GroupEditUserDialog : IUserDialog
    {
        public bool Edit(Entity entity)
        {
            Group group = (Group)entity;

            var viewModel = new CreateGroupWindowModel(group);
            var view = new CreateGroupWindow
            {
                DataContext = viewModel,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            if (view.ShowDialog() != true)
                return false;

            group.Name = viewModel.Name;

            return true;
        }

        public bool Create(Entity entity)
        {
            throw new NotImplementedException();
        }

        public bool ConfirmWarning(string Warning, string Caption)
        {
            throw new NotImplementedException();
        }

        public GroupEditUserDialog()
        {

        }
    }
}
