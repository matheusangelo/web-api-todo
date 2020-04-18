using System;
using Todo.Domain.Commands;

namespace ToDo.Domain.Tests.Mocks
{
    public static class CreateToDoCommandMock
    {
        public static CreateToDoCommand InvalidCommand()
        {
            return new CreateToDoCommand("", DateTime.Now, "");
        }

        public static CreateToDoCommand ValidCommand()
        {
            return new CreateToDoCommand("Estudar React e Angular", DateTime.Now, "Matheus Angelo");
        }
    }
}