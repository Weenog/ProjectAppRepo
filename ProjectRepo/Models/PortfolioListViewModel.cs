using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApp.Models
{
    public class PortfolioListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CompletionDate { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string Status { get; set; }
    }
}
