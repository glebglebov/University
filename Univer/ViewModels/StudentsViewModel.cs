﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Group> _GroupsList;

        #region Properties

        public ObservableCollection<Group> GroupsList
        {
            get => _GroupsList;
            set
            {
                _GroupsList = value;
                OnProperyChanged();
            }
        }

        private bool _IsStudentSelected = false;
        public bool IsStudentSelected
        {
            get => _IsStudentSelected;
            private set
            {
                _IsStudentSelected = (SelectedStudent != null) ? true : false;
                OnProperyChanged();
            }
        }

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
                IsStudentSelected = true;
                OnProperyChanged();
            }
        }

        #endregion

        #endregion

        #region Commands

        #region Command - group edit

        public ICommand GroupEditCommand { get; }

        private bool CanGroupEditExecute(object p) => p is Group;

        private void GroupEdit(object p)
        {
            var group = (Group)p;
            if (!_GroupEditDialog.Edit(group))
                return;

            _Groups.Update(group);

            var gr = GroupsList;
            GroupsList = null;
            GroupsList = gr;
        }

        #endregion

        #region Command - remove group

        public ICommand RemoveGroupCommand { get; }

        private void OnRemoveGroupCommandExecuted(object p)
        {
            if (!Dialog.ConfirmWarning("Вы уверены?", "Удалить группу"))
                return;

            Group group = (Group)p;

            GroupsList.Remove(group);
            _Groups.Delete(group.Id);
        }

        private bool CanRemoveGroupCommandExecute(object p) => p is Group;

        #endregion

        #endregion

        public StudentsViewModel(IRepository<Student> Students, IRepository<Group> Groups, IRepository<Mark> Marks)
        {
            _Students = Students;
            _Groups = Groups;
            _Marks = Marks;

            GroupsList = new ObservableCollection<Group>(_Groups.GetList);
            StudentsList = _Students.GetList.ToList();
            MarksList = _Marks.GetList.ToList();

            GroupEditCommand = new RelayCommand(GroupEdit, CanGroupEditExecute);
            RemoveGroupCommand = new RelayCommand(OnRemoveGroupCommandExecuted, CanRemoveGroupCommandExecute);

            _GroupEditDialog = new Dialog(); 
        }
    }
}
