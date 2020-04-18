using System;
using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Queries
{
    public static class ToDoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAllUsers(string User)
        {
            return x => x.User == User;
        }

        public static Expression<Func<TodoItem, bool>> GetAllItemByMark(string User, bool Mark)
        {
            return x => x.Done == Mark && x.User == User;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string User,
                                                                  DateTime date,
                                                                  bool Mark)
        {
            return x => x.Done == Mark &&
                    x.Date == date.Date &&
                    x.User == User;
        }
    }
}