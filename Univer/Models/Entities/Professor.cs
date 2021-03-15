using System;
using System.Collections.Generic;
using System.Text;

namespace Univer.Models.Entities
{
    public class Professor : Person
    {
        public string Degree { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
