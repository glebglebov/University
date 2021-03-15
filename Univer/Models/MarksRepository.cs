using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Univer.Models.Entities;

namespace Univer.Models
{
    class MarksRepository : DbRepository<Mark>
    {
        public override IQueryable<Mark> GetList => base.GetList.Include(item => item.Subject);

        public MarksRepository(StudentsContext context) : base(context)
        {

        }
    }
}
