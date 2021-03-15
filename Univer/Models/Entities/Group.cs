using System;
using System.Collections.Generic;
using System.Text;

namespace Univer.Models.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }


        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
