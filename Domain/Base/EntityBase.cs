using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public class EntityBase
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
