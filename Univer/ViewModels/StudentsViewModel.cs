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
    class StudentsViewModel : BaseViewModel
    {
        private IRepository<Student> _Students;
        private IRepository<Group> _Groups;

        #region Properties

        public List<Student> StudentsList { get; set; }
        public List<Group> GroupsList { get; set; }

        #region Property - Selected Group

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

        #endregion

        #region Property - Selected Student

        private Student _SelectedStudent;
        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set
            {
                _SelectedStudent = value;
                OnProperyChanged();
            }
        }

        #endregion

        #endregion

        public StudentsViewModel(IRepository<Student> Students, IRepository<Group> Groups)
        {
            _Students = Students;
            _Groups = Groups;

            StudentsList = _Students.GetList.ToList();
            GroupsList = _Groups.GetList.ToList();
        }
    }
}
