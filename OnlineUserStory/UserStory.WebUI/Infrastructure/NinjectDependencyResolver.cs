using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using UserStory.Domain.Abstract;
using UserStory.Domain.Entities;
using UserStory.Domain.Concrete;

namespace UserStory.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // put bindings here
            kernel.Bind<IStoryRepository>().To<EFStoryRepository>();

            // *** begin mock data
            //Mock<IStoryRepository> mock = new Mock<IStoryRepository>();
            //mock.Setup(m => m.Stories).Returns(new List<Story> {
            //    new Story { Title = "Football", StoryID = 25 },
            //    new Story { Title = "Surf board", StoryID = 35 },
            //    new Story { Title = "Running shoes", StoryID = 45 }
            //    });
            //kernel.Bind<IStoryRepository>().ToConstant(mock.Object);
            // *** end mock data

        }
    }
}