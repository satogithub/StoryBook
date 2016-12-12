using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserStory.Domain.Entities;
using System.Web.Mvc;

namespace UserStory.WebUI.Models
{
    public class CreateStoryViewModel
    {
        public Story Story { get; set; }
        public IEnumerable<Group> AllGroups { get; set; }
        public IEnumerable<SelectListItem> SLGroups { get; set; }

        private List<int> selectedCategories;
        public List<int> SelectedCategories
        {
            get
            {
                if (selectedCategories == null)
                {
                    selectedCategories = new List<int> { 1 };
                    //selectedCategories = SLGroups.Select(c => int.Parse(c.Value)).ToList();
                }
                return selectedCategories;
            }
            set
            {
                selectedCategories = value;
            }
        }
    }
}