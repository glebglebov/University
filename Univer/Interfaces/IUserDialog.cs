using System;
using System.Collections.Generic;
using System.Text;
using Univer.Models.Entities;

namespace Univer.Interfaces
{
    interface IUserDialog
    {
        bool Edit(Entity entity);

        bool Create(Entity entity);
    }
}
