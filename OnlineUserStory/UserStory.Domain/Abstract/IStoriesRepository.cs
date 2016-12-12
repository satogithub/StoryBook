using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStory.Domain.Entities;

namespace UserStory.Domain.Abstract
{
    public interface IStoryRepository
    {
        IEnumerable<Story> Stories { get; }

        void AddStory(Story story);

        IEnumerable<Group> Groups { get; }
    }
}
