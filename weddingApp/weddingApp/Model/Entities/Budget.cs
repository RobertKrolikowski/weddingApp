using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weddingApp.Model.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CoupleId { get; set; }
        public Couple Couple { get; set; }
    }
}
