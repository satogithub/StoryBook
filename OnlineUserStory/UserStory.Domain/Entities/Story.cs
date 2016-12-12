using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UserStory.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public ICollection<Group> Groups { get; set; }
    }

    public class Story
    {
        public int StoryID { get; set; }
        public string StoryTitle { get; set; }
        public string StoryDescription { get; set; }
        public string StoryContent { get; set; }
        public DateTime PostedOn { get; set; }
        public User StoryAuthor { get; set; }
        public ICollection<Group> Groups { get; set; }

    }

    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public ICollection<Story> Stories { get; set; }
        public ICollection<User> Users { get; set; }
    }

}
