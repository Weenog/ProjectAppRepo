using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApp.Domain
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PortfolioTag> PortfolioTags { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public PortfolioUser PortfolioUser { get; set; }
        public string PortfolioUserId { get; set; }

    }
}
