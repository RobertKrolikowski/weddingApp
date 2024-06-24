using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weddingApp.Model.Enum;

namespace weddingApp.Model.Entities
{
    public class WeddingService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ServiceType ServiceType { get; set; }
        public string ContactInfo { get; set; } 
    }
}
