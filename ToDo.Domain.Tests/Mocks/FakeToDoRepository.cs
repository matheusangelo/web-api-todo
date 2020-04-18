using System;
using System.Collections.Generic;
using Todo.Domain.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Tests.Mocks
{
    public class FakeToDoRepository : ITodoRepository
    {
        public void CreateItem(TodoItem task)
        {

        }

        public List<TodoItem> GetAllItemByMark(string User, bool Mark)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetAllUsers(string User)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetByPeriod(string User, bool Mark, DateTime date)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetItem(Guid Id, string User)
        {
            return new TodoItem("",DateTime.Now,"");
        }

        public void UpdateItem(TodoItem task)
        {
        }
    }
}