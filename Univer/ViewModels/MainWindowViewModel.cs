using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Univer.Models;
using Univer.Models.Entities;

namespace Univer.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private List<Student> _Students;
        private List<Group> _Groups;

        public BaseViewModel ActiveViewModel { get; set; }

        public MainWindowViewModel()
        {
            //DbInit.Init();

            var optionsBuilder = new DbContextOptionsBuilder<StudentsContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=University;Trusted_Connection=True;")
                    .Options;

            using (var db = new StudentsContext(options))
            {
                _Groups = db.Groups
                    .Include(g => g.Students)
                    .ToList();

                //_Students = db.Students.ToList();

            }

            ActiveViewModel = new StudentsViewModel(_Groups);
        }
    }
}
