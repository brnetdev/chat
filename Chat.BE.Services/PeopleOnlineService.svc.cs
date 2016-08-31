using Chat.BE.Contracts;
using Chat.BE.Contracts.DTO;
using Chat.BE.Domain.Commands.OnlinePerson;
using Chat.BE.Domain.Queries.Person;
using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Chat.BE.Services
{

    public class PeopleOnlineService : IPeopleOnlineService
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public PeopleOnlineService(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public void Add(PersonOnlineDTO personOnline)
        {            
            var command = new AddOnlinePersonCommand
            {
                ConectionId = personOnline.ConnectionId,
                Login = personOnline.Login,
                IsOnline = personOnline.IsOnline
            };
            _commandDispatcher.Execute<AddOnlinePersonCommand>(command);
            
        }

        public void Delete(string ConnectionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonOnlineDTO> Get()
        {
            List<PersonOnlineDTO> peopleOnline = new List<PersonOnlineDTO>();
            var result = _queryDispatcher.Run<GetOnlinePeopleQuery, GetOnlinePeopleQueryResult>(new GetOnlinePeopleQuery()).PeopleOnline;
            result.ForEach(item => 
            {
                peopleOnline.Add(new PersonOnlineDTO
                {
                    Id = item.Id,
                    ConnectionId = item.ConnectionId,
                    Login = item.Login,
                    IsOnline = item.Online
                });
            });

            return peopleOnline;
        }
    }
}
