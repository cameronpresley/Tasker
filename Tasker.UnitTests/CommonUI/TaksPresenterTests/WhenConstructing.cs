using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Tasker.CommonUI;
using Task = Tasker.Core.Task;

namespace Tasker.UnitTests.CommonUI.TaksPresenterTests
{
    [TestFixture]
    public class WhenConstructing
    {
        [Test]
        public void AndTheListOfTasksIsNullThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new TaskPresenter(null));
        }

        [Test]
        public void AndTheListOfTasksIsEmptyThen()
        {
            var presenter = new TaskPresenter(new List<Task>());

            Assert.AreEqual(0, presenter.CurrentPage);
        }

        [Test]
        public void ThenTheNumberOfTasksToShowIs10()
        {
            Assert.AreEqual(10, TaskPresenter.MaxToShowOnScreen);
        }

        [Test]
        public void AndTheListOfTasksIsEvenlyDivisibleByMaxToShowThenNoBufferIsNeeded()
        {
            var tasks = Enumerable.Range(1, TaskPresenter.MaxToShowOnScreen * 3)
                .Select(_ => Task.Create("title", "desc")).ToList();

            var presenter = new TaskPresenter(tasks);

            Assert.AreEqual(2, presenter.NumberOfPages);
        }
    }
}
