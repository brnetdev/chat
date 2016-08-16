using Chat.BE.Contracts.DTO;
using Chat.BE.Contracts.Faults;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Contracts
{
    //[ContractClass(typeof(RoomServiceContractClass))]
    [ServiceContract]
    public interface IRoomService
    {
        /// <summary>
        /// Dodaje pokój chat
        /// </summary>
        /// <param name="room"></param>
        [OperationContract]
        [FaultContract(typeof(FaultDataContract))]
        void Add(RoomDTO room);

        /// <summary>
        /// Usuwa pokój
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        [FaultContract(typeof(FaultDataContract))]
        void Remove(int id);

        /// <summary>
        /// Pobiera kolekcję pokoi, posortowanych po nazwie
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultDataContract))]
        IEnumerable<RoomDTO> GetAll();
        
    }

    ////[ContractClassFor(typeof(IRoomService))]
    //public class RoomServiceContractClass : IRoomService
    //{
    //    public void Add(RoomDTO room)
    //    {
    //        Contract.Requires(room != null);
    //        Contract.Requires(!string.IsNullOrEmpty(room.Name));

    //    }

    //    public IEnumerable<RoomDTO> GetAll()
    //    {
    //        Contract.Ensures(Contract.Result<IEnumerable<RoomDTO>>() != null);
    //        //Contract.Ensures(Contract.Result<IEnumerable<RoomDTO>>().Any());

    //        return default (IEnumerable<RoomDTO>);
    //    }

    //    public void Remove(int id)
    //    {
    //        Contract.Requires(id > 0);
    //    }
    //}


}
