using Chat.BE.Data;
using Chat.BE.Domain.Commands.Room;
using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Domain.Handlers.Command
{
    public class AddRoomCommandHandler : ICommandHandler<AddRoomCommand>
    {
        public IStatusResult Handle(AddRoomCommand command)
        {
            Contract.Requires(command != null);            
            Contract.Ensures(Contract.Result<AddRoomCommandStatus>().Id > 0);
            
            using (Db db = new Db())
            {
                var newRoom = new Data.Entities.Room { Description = command.Description, Title = command.Title };
                db.Rooms.Add(newRoom);
                return new AddRoomCommandStatus { Id = newRoom.Id };
            }            
        }
    }
}
