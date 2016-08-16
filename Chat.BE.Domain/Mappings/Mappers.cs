using AutoMapper;
using Chat.BE.Contracts.DTO;
using Chat.BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Domain.Mappings
{
    public static class Mappers
    {
        private static IMapper _mapper;

        public static IMapper MapperObj { get { return _mapper; } }
        static Mappers()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<RoomDTO, Room>();
                cfg.CreateMap<Room, RoomDTO>();
                cfg.CreateMap<List<RoomDTO>, List<Room>>();
                cfg.CreateMap<List<Room>, List<RoomDTO>>();

            });
            _mapper = Mapper.Instance;
        }

        public static RoomDTO ToDTO(this Room room)
        {
            return _mapper.Map<RoomDTO>(room);
        }

        public static Room ToEntity(this RoomDTO roomDto)
        {
            return _mapper.Map<Room>(roomDto);
        }

        public static List<RoomDTO> ToDTOCollection(this List<Room> rooms)
        {
            return _mapper.Map<List<RoomDTO>>(rooms);
        }

        public static List<Room> ToEntitiesCollection(this List<RoomDTO> roomDtos)
        {
            return _mapper.Map<List<Room>>(roomDtos);
        }





    }
}
