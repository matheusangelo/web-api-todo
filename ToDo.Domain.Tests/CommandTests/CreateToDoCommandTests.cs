using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using ToDo.Domain.Tests.Mocks;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateToDoCommandTests
    {
        [TestMethod]
        public void ShouldRetornInvalidWhenEnterNullData()
        {
            var command = CreateToDoCommandMock.InvalidCommand();
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void ShouldRetornTrueWhenEnterValidData()
        {
            var command = CreateToDoCommandMock.ValidCommand();
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
    }
}