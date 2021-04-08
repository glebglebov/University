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
    class MarksEditWindowViewModel : BaseViewModel
    {
        private readonly ICollection<Mark> _Marks;

        private readonly IRepository<Subject> _Subjects;

        public ObservableCollection<Mark> Marks { get; set; }

        public List<Subject> Subjects { get; set; }

        public ICommand SaveMarks { get; }

        private void OnSaveMarksExecuted(object p)
        {
            App.CurrentWindow.DialogResult = true;
        }

        private bool CanSaveChangesExecute(object p) => true;

        public MarksEditWindowViewModel(ICollection<Mark> marks)
        {
            Title = "Редактор оценок";

            _Marks = marks;
            Marks = new ObservableCollection<Mark>(_Marks);

            _Subjects = new DbRepository<Subject>(App.Db);
            Subjects = _Subjects.GetList.ToList();

            SaveMarks = new RelayCommand(OnSaveMarksExecuted, CanSaveChangesExecute);
        }
    }
}
