using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modas.Models
{
    public class EventPaginationViewModel
    {
        public int TotalResults { get; set; }
        public int MinPage { get; set; }
        public int MaxPage { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentMinResult { get; set; }
        public int CurrentMaxResult { get; set; }
        public IEnumerable<Event> Events { get; set; }


    }
}
