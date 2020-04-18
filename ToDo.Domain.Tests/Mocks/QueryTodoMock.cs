using System;
using System.Collections.Generic;
using Todo.Domain.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Tests.Mocks
{
    public static class QueryTodoMock
    {
        public static List<TodoItem> GetAllTodos()
        {

            var todos = new List<TodoItem>();

            var todoItem = new TodoItem("Teste", DateTime.Now, "Matheus Angelo");
            var invalidTodoItem = new TodoItem("", DateTime.Now, "");

            todos.Add(todoItem);
            todos.Add(invalidTodoItem);

            return todos;
        }
    }
}