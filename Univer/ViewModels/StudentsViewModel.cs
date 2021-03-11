using System;
using System.Collections.Generic;
using System.Text;

namespace Univer.ViewModels
{
    class StudentsViewModel : BaseViewModel
    {
        public List<string> Test { get; set; }

        public StudentsViewModel()
        {
            Test = new List<string> { "aaa", "bbb", "ccc" };
        }
    }
}
