using System;
using System.Collections.Generic;
using System.Text;

namespace Univer.Models.Entities
{
    public class Student : Person
    {
        public virtual Group Group { get; set; }

        public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();
    }
}
