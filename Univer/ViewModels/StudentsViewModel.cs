using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Univer.Models;
using Univer.Models.Entities;

namespace Univer.ViewModels
{
    class StudentsViewModel : BaseViewModel
    {
        public List<Student> Students { get; set; }
        public List<Group> Groups { get; set; }

        private Group _SelectedGroup;
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set
            {
                _SelectedGroup = value;
                OnProperyChanged();
            }
        }

        public StudentsViewModel(List<Group> Groups)
        {
            //this.Students = Students;
            this.Groups = Groups;

            //using (var db = new StudentsContext(options))
            //{
                //var group1 = new Group()
                //{
                //    Name = "АААА-01-01"
                //};

                //db.Groups.Add(group1);

                //var stud1 = new Student()
                //{
                //    Name = "Глеб",
                //    Surname = "Шалимов",
                //    Birthday = DateTime.Now,
                //    Group = group1
                //};

                //var stud2 = new Student()
                //{
                //    Name = "Глеб",
                //    Surname = "Глебов",
                //    Birthday = DateTime.Now,
                //    Group = group1
                //};

                //db.Students.Add(stud1);
                //db.Students.Add(stud2);

                //db.SaveChanges();

            //}
        }
    }
}
