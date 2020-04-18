using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;
using ToDo.Domain.Entities;

namespace Todo.Domain.Handlers
{
    public class HandlerCreateToDoItem :
    Notifiable,
    IHandler<CreateToDoCommand>
    {

        public readonly ITodoRepository _todoRepository;
        public HandlerCreateToDoItem(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public ICommandResult Handle(CreateToDoCommand command)
        {
            //fast fail validation
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Requisição falhou", command.Notifications);

            }

            //gerar o todo

            var todo = new TodoItem(command.Title, command.Date, command.User);

            //persiste no banco
            _todoRepository.CreateItem(todo);


            return new CommandResult(true, "Tarefa criada com sucesso", todo);
        }
    }
}