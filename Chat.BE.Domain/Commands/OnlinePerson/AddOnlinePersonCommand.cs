using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Domain.Commands.OnlinePerson
{
    public class AddOnlinePersonCommand : ICommand
    {
        public string Login { get; set; }
        public bool IsOnline { get; set; }
        public string ConectionId { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(ConectionId);
        }
    }

    public class AddOnlineCommandStatus : IStatusResult
    {
        public int Id { get; set; }
    }

}
