using System;
using System.Collections.Generic;
using System.Text;

namespace Univer.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        public BaseViewModel ActiveViewModel { get; set; } = new StudentsViewModel();

        public MainWindowViewModel()
        {

        }
    }
}
