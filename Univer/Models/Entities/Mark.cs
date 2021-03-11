using System;
using System.Collections.Generic;
using System.Text;

namespace Univer.Models.Entities
{
    class Mark : Entity
    {
        public int Score { get; set; }

        public string Comment { get; set; }


        public virtual Subject Subject { get; set; }
        
        public virtual Student Student { get; set; }
    }
}
