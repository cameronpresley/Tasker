using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tasker.Core.UnitTests.TaskerTests
{
    [TestFixture]
    public class WhenCreatingATask
    {
        [Test]
        public void AndTheNameIsNullThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => Task.Create(null, "desc"));
        }

        [Test]
        public void AndTheNameIsEmptyThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => Task.Create("", "desc"));
        }

        [Test]
        public void AndTheDescriptionIsNullThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => Task.Create("title", null));
        }

        [Test]
        public void AndTheDescriptionIsEmptyThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => Task.Create("title", ""));
        }

        [Test]
        public void ThenTheTaskIsCreated()
        {
            var task = Task.Create("title", "desc");

            Assert.AreEqual("title", task.Title);
            Assert.AreEqual("desc", task.Description);
            Assert.AreEqual(-1, task.Id);
            Assert.AreEqual(TaskStatus.ToDo, task.Status);
        }
    }
}
