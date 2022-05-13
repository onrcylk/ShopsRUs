using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public bool isDeleted { get; set; }
    }
}
