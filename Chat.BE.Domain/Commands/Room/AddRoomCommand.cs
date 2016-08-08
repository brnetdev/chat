using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Domain.Commands.Room
{
    public class AddRoomCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Title);

        }
    }

    public class AddRoomCommandStatus : IStatusResult
    {
        public int Id { get; set; }
    }

}
