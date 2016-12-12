using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserStory.Domain.Entities;

namespace UserStory.WebUI.Models
{
    public class StoriesCardsViewModel
    {
        public IEnumerable<Story> Stories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}