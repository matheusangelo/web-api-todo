using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    //assinatura da interface é do tipo de classe T que iremos passar onde T é uma classe do tipo ICommand
    public interface IHandler<T> where T : ICommand
    {

        ICommandResult Handle(T command);
    }
}