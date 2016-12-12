using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserStory.Domain.Abstract;
using UserStory.Domain.Entities;
using UserStory.WebUI.Models;

namespace UserStory.WebUI.Controllers
{
    public class StoryController : Controller
    {
        private IStoryRepository repository;
        public int PageSize = 4;

        public StoryController(IStoryRepository storytRepository)
        {
            this.repository = storytRepository;
        }



        public ViewResult MyStories(int page = 1)
        {
            StoriesCardsViewModel model = new StoriesCardsViewModel
            {
                Stories = repository.Stories.OrderBy(s => s.StoryID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Stories.Count()
                }
            };

            var formView = repository.Stories.OrderBy(s => s.StoryID).Skip((page - 1) * PageSize).Take(PageSize);
            //return View(repository.Stories);
            return View(model);
        }

        public ViewResult CreateStory(int? storyID)
        {
            CreateStoryViewModel model = Populate();
            if (storyID != null)
            {
                model.Story = repository.Stories.FirstOrDefault(m => m.StoryID == storyID);
                model.SelectedCategories = repository.Stories.FirstOrDefault(m => m.StoryID == storyID).Groups.Select(g=>g.GroupID).ToList();
            }
            return View(model);
        }

        private CreateStoryViewModel Populate()
        {//
            CreateStoryViewModel model = new CreateStoryViewModel();
            model.AllGroups = repository.Groups;
            IEnumerable<Group> groupsList = repository.Groups.ToList();
            model.SLGroups = groupsList.Select(g => new SelectListItem
            {
                Text = g.GroupName,
                Value = g.GroupID.ToString()
            });
            model.SelectedCategories = new List<int> { 1 };
            
            return model;
        }

        [HttpPost]
        public ActionResult CreateStory(CreateStoryViewModel model)
        {
            Story adaptedModel = new Story {
                StoryTitle = model.Story.StoryTitle,
                StoryDescription = model.Story.StoryDescription,
                StoryContent = model.Story.StoryContent,
                PostedOn = DateTime.Now,
                Groups = repository.Groups.Where(l => model.SelectedCategories.Contains(l.GroupID)).ToList()
            };

            IEnumerable<Group> groupsList = repository.Groups.ToList();
            model.SLGroups = groupsList.Select(g => new SelectListItem
            {
                Text = g.GroupName,
                Value = g.GroupID.ToString()
            });

            //if (ModelState.IsValid)
            if (true)
            {
                repository.AddStory(adaptedModel);
                return RedirectToAction("MyStories");
            }
            else
            {
                IEnumerable<Group> groupsListLocal = repository.Groups.ToList();
                model.SLGroups = groupsListLocal.Select(g => new SelectListItem
                {
                    Text = g.GroupName,
                    Value = g.GroupID.ToString()
                });
                return View(model);
            }


        }

        public ActionResult ShowAllGroups()
        {
            IEnumerable<Group> groupsDataList = repository.Groups.ToList();
            GroupsCardsViewModel model = new GroupsCardsViewModel
            {
                GroupDatas = groupsDataList.Select(m => new GroupsCardsViewModel.GroupData {
                    GroupName = m.GroupName,
                    GroupDescription = m.GroupDescription,
                    MemberCount = GetMemberCount(m.GroupID),
                    StoriesCount = GetStoriesCount(m.GroupID)
                })
            };
            return View(model);
        }

        private int GetMemberCount(int groupID)
        {
            var memberCount = repository.Groups.First(g => g.GroupID == groupID).Users;
            return memberCount != null ? memberCount.Count() : 0;
        }

        private int GetStoriesCount(int groupID)
        {
            var storiesCount = repository.Groups.First(g => g.GroupID == groupID).Stories;
            return storiesCount != null ? storiesCount.Count() : 0;
        }


        public ActionResult EditStory(int? storyID)
        {
            Story model = new Story();
            if (storyID!=null)
            {
                model = repository.Stories.FirstOrDefault(m => m.StoryID == storyID);
            }
            return View("CreateStory", model);
        }



    }
}