using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weddingApp.Model.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int CoupleId { get; set; }
        public Couple Couple { get; set; }
    }
}
