using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Addrees { get; set; } = string.Empty;
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public List<KeyValue> Contacts { get; set; } = new List<KeyValue>();

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public ICollection<User> Staff { get; set; } = new List<User>();
    }
}
