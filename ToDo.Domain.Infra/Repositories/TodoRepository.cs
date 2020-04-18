using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Repositories;
using ToDo.Domain.Entities;
using ToDo.Domain.Infra.Contexts;
using ToDo.Domain.Queries;

namespace Todo.Domain.Infra.Repositories
{
    public class ToDoRepository : ITodoRepository
    {

        private readonly ToDoContext _todoContext;

        public ToDoRepository(ToDoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public void CreateItem(TodoItem task)
        {
            _todoContext.Add(task);
            _todoContext.SaveChanges();
        }

        public List<TodoItem> GetAllItemByMark(string User, bool Mark)
        {
            return _todoContext.todoItems
                                .AsNoTracking()
                                .Where(ToDoQueries.GetAllItemByMark(User,Mark))
                                .ToList();
        }

        public List<TodoItem> GetAllUsers(string User)
        {
            return _todoContext.todoItems
                                .AsNoTracking()
                                .Where(ToDoQueries.GetAllUsers(User))
                                .ToList();
        }

        public List<TodoItem> GetByPeriod(string User, bool Mark, DateTime date)
        {
            return _todoContext.todoItems
                                .AsNoTracking()
                                .Where(ToDoQueries.GetByPeriod(User,date,Mark))
                                .ToList();
        }

        public TodoItem GetItem(Guid Id, string User)
        {
            return _todoContext.todoItems
                                .AsNoTracking()
                                .Where(x => x.Id == Id && x.User == User)
                                .FirstOrDefault();
        }

        public void UpdateItem(TodoItem task)
        {
            //ENTRY SELECIONA A ENTIDADE PASSADA DE ACORDO COM O PARAMETRO
            _todoContext.Entry(task).State = EntityState.Modified;
            _todoContext.SaveChanges();
        }
    }
}