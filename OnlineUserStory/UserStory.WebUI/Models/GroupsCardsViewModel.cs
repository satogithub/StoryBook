using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserStory.Domain.Entities;

namespace UserStory.WebUI.Models
{
    public class GroupsCardsViewModel
    {
        public class GroupData : Group
        {
            public int MemberCount { get; set; }
            public int StoriesCount { get; set; }
        }

        public IEnumerable<GroupData> GroupDatas { get; set; }
    }
}