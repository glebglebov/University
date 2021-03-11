using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Univer.Models.Entities;

namespace Univer.Models
{
    class GroupsRepository : DbRepository<Group>
    {
        public override IQueryable<Group> GetList => base.GetList.Include(item => item.Students);

        public GroupsRepository() : base()
        {

        }
    }
}
