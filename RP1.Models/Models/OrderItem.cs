using MyProject_L00181476.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RP1.Models.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int GolfBallId { get; set; }
        public GolfBall GolfBall { get; set; }
        public int QtyOrdered { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
