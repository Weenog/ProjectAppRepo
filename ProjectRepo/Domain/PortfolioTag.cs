using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApp.Domain
{
    public class PortfolioTag
    {
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
