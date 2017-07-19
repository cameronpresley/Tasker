using System;
using NUnit.Framework;

namespace Tasker.UnitTests.InputToUserCommandConverterTests
{
    [TestFixture]
    public class WhenConvertingToCommand
    {
        [Test]
        public void AndTheInputIsNullThenAnExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => InputToUserCommandConverter.Convert(null));
        }

        [Test]
        public void AndTheInputIsEmptyThenUnknownIsReturned()
        {
            var result = InputToUserCommandConverter.Convert(string.Empty);

            Assert.AreEqual(UserCommand.Unknown, result);
        }

        [TestCase("add")]
        [TestCase("ADD")]
        [TestCase("AdD")]
        public void AndTheInputIsAddThenAddTaskIsReturned(string add)
        {
            var result = InputToUserCommandConverter.Convert(add);

            Assert.AreEqual(UserCommand.AddTask, result);
        }

        [TestCase("quit")]
        [TestCase("Quit")]
        [TestCase("QUIT")]
        public void AndTheInputIsQuitThenQuitIsReturned(string quit)
        {
            var result = InputToUserCommandConverter.Convert(quit);

            Assert.AreEqual(UserCommand.Quit, result);
        }

        [Test]
        public void AndTheInputIs1ThenAddTaskIsReturned()
        {
            var result = InputToUserCommandConverter.Convert("1");

            Assert.AreEqual(UserCommand.AddTask, result);
        }

        [Test]
        public void AndTheInputIs2ThenShowIsReturned()
        {
            var result = InputToUserCommandConverter.Convert("2");

            Assert.AreEqual(UserCommand.ShowTasks, result);
        }

        [Test]
        public void AndTheInputIs3ThenQuitIsReturned()
        {
            var result = InputToUserCommandConverter.Convert("3");

            Assert.AreEqual(UserCommand.Quit, result);
        }

        [Test]
        public void ThenUnknownIsReturned()
        {
            var result = InputToUserCommandConverter.Convert("badInput");

            Assert.AreEqual(UserCommand.Unknown, result);
        }
    }
}
