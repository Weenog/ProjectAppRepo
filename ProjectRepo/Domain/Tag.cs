using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApp.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<PortfolioTag> PortfolioTags { get; set; }
    }
}