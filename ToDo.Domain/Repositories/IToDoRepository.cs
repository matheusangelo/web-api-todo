using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        TodoItem GetItem(Guid Id, string User);
        void CreateItem(TodoItem task);
        void UpdateItem(TodoItem task);
        List<TodoItem> GetAllUsers(string User);
        List<TodoItem> GetAllItemByMark(string User, bool Mark);
        List<TodoItem> GetByPeriod(string User, bool Mark, DateTime date);


    }
}