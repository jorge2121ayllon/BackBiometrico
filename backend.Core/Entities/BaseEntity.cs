using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Erased { get; set; }
        public DateTime Date { get; set; }

    }
}
