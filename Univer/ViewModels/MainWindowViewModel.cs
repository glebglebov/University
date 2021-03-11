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
        private IRepository<Student> _Students;
        private IRepository<Group> _Groups;

        public BaseViewModel ActiveViewModel { get; set; }

        public MainWindowViewModel()
        {
            _Students = new DbRepository<Student>();
            _Groups = new GroupsRepository();

            ActiveViewModel = new StudentsViewModel(_Students, _Groups);
        }
    }
}
