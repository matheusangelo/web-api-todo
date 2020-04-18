using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using ToDo.Domain.Queries;
using ToDo.Domain.Tests.Mocks;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class ToDoQueriesTests
    {
        [TestMethod]
        public void ShouldRetornNothingWhenDoNotFindAObject()
        {
            var queryTest = QueryTodoMock.GetAllTodos()
                            .AsQueryable()
                            .Where(ToDoQueries.GetAllUsers("Test"));


            Assert.AreEqual(queryTest.Count(), 0);
        }

        [TestMethod]
        public void ShouldRetornWhenDoNotFindAObject()
        {
            var queryTest = QueryTodoMock.GetAllTodos()
                .AsQueryable()
                .Where(ToDoQueries.GetAllUsers("Matheus Angelo"));


            Assert.AreEqual(queryTest.Count(), 1);
        }
    }
}