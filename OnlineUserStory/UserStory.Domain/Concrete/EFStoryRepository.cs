using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStory.Domain.Abstract;
using UserStory.Domain.Entities;

namespace UserStory.Domain.Concrete
{
    public class EFStoryRepository : IStoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Story> Stories { get { return context.Stories.Include("Groups"); } }

        public void AddStory(Story story)
        {
            if (story.StoryID==0)
            {
                context.Stories.Add(story);
            }

            context.SaveChanges();
        }

        public IEnumerable<Group> Groups { get { return context.Groups.Include("Stories").Include("Users"); } }

    }
}
