namespace UserStory.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<UserStory.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserStory.Domain.Concrete.EFDbContext context)
        {
            DateTime strt = DateTime.Now;
            for (int i = 1; i < 11; i++)
            {
                strt = strt.AddMinutes(10);
                context.Stories.AddOrUpdate(
                new Entities.Story
                {
                    StoryID = i,
                    StoryTitle = "Title" + i,
                    StoryDescription = "Description for our story " + i,
                    StoryContent = "Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. ",
                    PostedOn = strt,
                    Groups = context.Groups.Where(g => g.GroupID == 2).ToList()
                });
            }

            for (int i = 1; i < 6; i++)
            {
                context.Groups.AddOrUpdate(
                    new Entities.Group
                    {
                        GroupID = i,
                        GroupName = "GroupName" + i,
                        GroupDescription = "GroupDescription for this group " + i
                    });

            }

            for (int i = 1; i < 6; i++)
            {
                context.Users.AddOrUpdate(
                    new Entities.User
                    {
                        UserID = i,
                        UserName = "UserName" + i,
                        Groups = context.Groups.Where(g => g.GroupID==3).ToList()
                    });

            }

           
        }
    }
}
