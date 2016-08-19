using Chat.BE.Contracts;
using Chat.BE.Contracts.DTO;
using Chat.BE.Domain.Queries.Room;
using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;

namespace Chat.BE.Services
{
    public class RoomService : IRoomService
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public RoomService(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public void Add(RoomDTO room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomDTO> GetAll()
        {
            var result = _queryDispatcher.Run<GetAllRoomsQuery, GetAllRoomsQueryResult>(new GetAllRoomsQuery());
            return result.Rooms;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
