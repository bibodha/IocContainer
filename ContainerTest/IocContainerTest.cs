using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IocContainer;

namespace ContainerTest
{
    [TestFixture]
    class IocContainerTest
    {
        [Test]
        public void TestRegisterWithoutParams()
        {
            Container cont = new Container();
            bool result = cont.Register<IRepository, Repository>();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestRegisterWithParams()
        {
            Container cont = new Container();
            bool result = cont.Register<IRepository, Repository>(LifestyleType.Transient);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestRegisterWithTransient()
        {
            Container cont = new Container();
            cont.Register<IRepository, Repository>(LifestyleType.Transient);
            cont.Register<IServiceProvider, Service>();
            IRepository repo1 = cont.Resolve<IRepository>();
            IRepository repo2 = cont.Resolve<IRepository>();
            bool result = repo1 == repo2;
            Assert.AreNotEqual(true, result);
        }

        [Test]
        public void TestRegisterWithSingleton()
        {
            Container cont = new Container();
            cont.Register<IRepository, Repository>(LifestyleType.Singleton);
            cont.Register<IServiceProvider, Service>(LifestyleType.Singleton);
            IRepository repo1 = cont.Resolve<IRepository>();
            IRepository repo2 = cont.Resolve<IRepository>();
            bool result = repo1.Equals(repo2);
            Assert.AreEqual(true, result);
        }

        [Test]
        [ExpectedException(typeof(NotRegisteredException))]
        public void TestResolveThatWillThrowAnException()
        {
            Container cont = new Container();
            cont.Register<IRepository, Repository>();
            IRepository repo = cont.Resolve<IRepository>();
        }

        [Test]
        public void TestResolve()
        {
            Container cont = new Container();
            cont.Register<IRepository, Repository>();
            cont.Register<IServiceProvider, Service>();
            IRepository repo = cont.Resolve<IRepository>();
            string result = repo.ShowMessage("This is a test");
            StringAssert.AreEqualIgnoringCase("This is a test", result);
        }
    }
}
