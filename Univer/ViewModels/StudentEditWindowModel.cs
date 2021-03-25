using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Univer.Commands;
using Univer.Interfaces;
using Univer.Models;
using Univer.Models.Entities;

namespace Univer.ViewModels
{
    class StudentEditWindowModel : BaseViewModel
    {
        private readonly Student _Student;

        private readonly IRepository<Group> _Groups;

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public Group Group { get; set; }

        public List<Group> Groups { get; }

        public ICommand SaveChangesCommand { get; }

        private void OnSaveChangesExecuted(object p)
        {
            App.CurrentWindow.DialogResult = true;
        }

        private bool CanSaveChangesExecute(object p) => true;

        public StudentEditWindowModel(Student student)
        {
            _Student = student;

            Name = student.Name;
            Surname = student.Surname;
            Patronymic = student.Patronymic;
            Birthday = student.Birthday;
            Group = student.Group;

            Title = Name + " " + Surname;

            _Groups = new DbRepository<Group>(App.Db);
            Groups = _Groups.GetList.ToList();

            SaveChangesCommand = new RelayCommand(OnSaveChangesExecuted, CanSaveChangesExecute);
        }
    }
}
