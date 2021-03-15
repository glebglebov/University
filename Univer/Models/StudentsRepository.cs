using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Univer.Models.Entities;

namespace Univer.Models
{
    class StudentsRepository : DbRepository<Student>
    {
        public override IQueryable<Student> GetList => base.GetList
            .Include(item => item.Marks)
        ;

        public StudentsRepository(StudentsContext context) : base(context)
        {
               
        }
    }
}
