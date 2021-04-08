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
    class Dialog
    {
        public static bool GroupEdit(Group group)
        {
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

        public static bool StudentEdit(Student student)
        {
            var viewModel = new StudentEditWindowModel(student);
            var view = new StudentEditView
            {
                DataContext = viewModel
            };

            if (view.ShowDialog() != true)
                return false;

            student.Name = viewModel.Name;
            student.Surname = viewModel.Surname;
            student.Patronymic = viewModel.Patronymic;
            student.Birthday = viewModel.Birthday;
            student.Group = viewModel.Group;

            App.Db.SaveChanges();

            return true;
        }

        public static bool MarksEdit(ICollection<Mark> marks)
        {
            var viewModel = new MarksEditWindowViewModel(marks);
            var view = new MarksEditWindow
            {
                DataContext = viewModel
            };

            if (view.ShowDialog() != true)
                return false;

            marks = viewModel.Marks;

            App.Db.SaveChanges();

            return true;
        }

        public static bool ConfirmWarning(string Warning, string Caption)
            => MessageBox.Show(Warning, Caption, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;

        public Dialog()
        {

        }
    }
}
