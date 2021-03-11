using System;
using System.Collections.Generic;
using System.Text;

namespace Univer.Models.Entities
{
    abstract class Person : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }
    }
}
