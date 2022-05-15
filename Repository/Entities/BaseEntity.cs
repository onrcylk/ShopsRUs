using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository.Entities
{
    public abstract class BaseEntity
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedTime { get; set; }
        [JsonIgnore]
        public bool isDeleted { get; set; }
    }
}
