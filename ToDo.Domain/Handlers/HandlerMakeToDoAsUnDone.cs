using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class HandlerMakeTodoAsUndone : Notifiable, IHandler<UpdateToDoCommand>
    {

        public readonly ITodoRepository _todoRepository;
        public HandlerMakeTodoAsUndone(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public ICommandResult Handle(UpdateToDoCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Falha na atualização", command);
            }

            //get todo item
            var todo = _todoRepository.GetItem(command.Id, command.User);

            //Att Item
            todo.MarkAsUndone();

            _todoRepository.UpdateItem(todo);
            //return result
            return new CommandResult(true, "Atualização realizada com sucesso", command);
        }
    }
}