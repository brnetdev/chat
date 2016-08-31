using Chat.BE.Data;
using Chat.BE.Domain.Commands.OnlinePerson;
using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Domain.Handlers.Command
{
    public class AddOnlinePersonCommandHandler : ICommandHandler<AddOnlinePersonCommand>
    {
        public IStatusResult Handle(AddOnlinePersonCommand command)
        {
            Contract.Ensures(Contract.Result<AddOnlineCommandStatus>().Id != 0);

            using (Db db = new Db())
            {
                var entity = new Data.Entities.OnlinePerson
                {
                    ConnectionId = command.ConectionId,
                    Login = command.Login,
                    OnLine = command.IsOnline
                };

                db.OnlinePeople.Add(entity);
                db.SaveChanges();
                return new AddOnlineCommandStatus { Id = entity.Id };
            }
        }
    }
}
