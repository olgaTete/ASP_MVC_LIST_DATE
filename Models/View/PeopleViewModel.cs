using ListDate2.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListDate2.Models.View
{
    public class PeopleViewModel
    {
        public List<Person>? People { get; set; }
        public string PersonName { get; set; }
        public string PersonCity { get; set; }
        public string SearchString { get; set; }
        public string SearchResult { get; set; }

    }
}
