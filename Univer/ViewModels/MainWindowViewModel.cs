using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Univer.Interfaces;
using Univer.Models;
using Univer.Models.Entities;

namespace Univer.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private readonly IRepository<Student> _Students;
        private readonly IRepository<Group> _Groups;
        private readonly IRepository<Mark> _Marks;
        private readonly IRepository<Subject> _Subjects;

        public BaseViewModel ActiveViewModel { get; set; }

        public MainWindowViewModel()
        {
            _Students = new DbRepository<Student>(App.Db);
            _Groups = new DbRepository<Group>(App.Db);
            _Marks = new MarksRepository(App.Db);

            ActiveViewModel = new StudentsViewModel(_Students, _Groups, _Marks);
        }
    }
}
