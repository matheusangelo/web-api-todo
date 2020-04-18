//comandos são ações representadas na API
using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{

    //os atributos da classe é de acordo com os atributos da classe para se realizar o comando
    //por exemplo o create todoItem precisa de  title,  date, string user
    public class MakeToDoAsUnDoneCommand : Notifiable, ICommand
    {
        public MakeToDoAsUnDoneCommand() { }

        public MakeToDoAsUnDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(User,3,"User","Usuário - Quantidade Mínima de 3 digitos")
            );
        }
    }
}