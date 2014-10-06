using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeBox.Models
{
    public class SearchResultModel
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public string ImageName { get; set; }
        public string PhaseLink { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}