using System;
using System.Collections.Generic;
using System.Text;

namespace Univer.Models.Entities
{
    class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public Group Group { get; set; }
    }
}
