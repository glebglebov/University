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
    class Dialog : IUserDialog
    {
        public bool Edit(Entity entity)
        {
            Group group = (Group)entity;

            var viewModel = new GroupEditWindowModel(group);
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

        public static bool ConfirmWarning(string Warning, string Caption)
            => MessageBox.Show(Warning, Caption, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;

        public Dialog()
        {

        }
    }
}
