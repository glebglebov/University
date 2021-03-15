using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Univer.Models;

namespace Univer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static StudentsContext _db;
        public static StudentsContext Db => _db;

        public App()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentsContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=University;Trusted_Connection=True;")
                    .Options;

            _db = new StudentsContext(options);
        }
    }
}
