using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers;
using ToDo.Domain.Tests.Mocks;

namespace ToDo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateToDoHanderTests
    {
        [TestMethod]
        public void ShouldReturnFailWhenSendAInvalidCommand()
        {
            var handler = new HandlerCreateToDoItem(new FakeToDoRepository());
            var result = (CommandResult)handler.Handle(CreateToDoCommandMock.InvalidCommand());

            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenSendAValidCommand()
        {
            var handler = new HandlerCreateToDoItem(new FakeToDoRepository());
            var result = (CommandResult)handler.Handle(CreateToDoCommandMock.ValidCommand());

            Assert.AreEqual(result.Success, true);
        }
    }
}