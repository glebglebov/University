﻿using Microsoft.EntityFrameworkCore;
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
    class StudentsViewModel : BaseViewModel
    {
        private IUserDialog _GroupEditDialog;

        private IRepository<Student> _Students;
        private IRepository<Group> _Groups;
        private IRepository<Mark> _Marks;

        #region Properties

        public List<Group> GroupsList { get; set; }
        public List<Mark> MarksList { get; set; }
        public List<Student> StudentsList { get; set; }

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

        public ICommand GroupEditCommand { get; }

        private bool CanGroupEditExecute(object p) => p is Group;

        private void GroupEdit(object p)
        {
            var group = (Group)p;
            if (!_GroupEditDialog.Edit(group))
                return;

            _Groups.Update(group);

        }

        public StudentsViewModel(IRepository<Student> Students, IRepository<Group> Groups, IRepository<Mark> Marks)
        {
            _Students = Students;
            _Groups = Groups;
            _Marks = Marks;

            GroupsList = _Groups.GetList.ToList();
            StudentsList = _Students.GetList.ToList();
            MarksList = _Marks.GetList.ToList();

            GroupEditCommand = new RelayCommand(GroupEdit, CanGroupEditExecute);
            _GroupEditDialog = new GroupEditUserDialog(); 
        }
    }
}
