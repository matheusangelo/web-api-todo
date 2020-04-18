//comandos são ações representadas na API
using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{

    //os atributos da classe é de acordo com os atributos da classe para se realizar o comando
    //por exemplo o create todoItem precisa de  title,  date, string user
    public class CreateToDoCommand : Notifiable, ICommand
    {
        public CreateToDoCommand() { }
        public CreateToDoCommand(string title, DateTime date, string user)
        {
            Title = title;
            Date = date;
            User = user;
        }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Descreva melhor esta tarefa")
                    .HasMinLen(User, 6, "User", "Usuário Inválido")
            );
        }
    }
}