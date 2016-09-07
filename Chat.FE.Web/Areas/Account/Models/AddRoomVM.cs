using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Chat.FE.Web.Areas.Account.Models
{
        
    public class AddRoomVM
    {
        [MinLength(2, ErrorMessage="Minimalna długość nazwy to 2 znaki")]
        [MaxLength(15, ErrorMessage="Maksykalna długość pola to 15 znaków")]
        [Required(ErrorMessage="Pole nazwa jest wymagane")]
        [DisplayName("Nazwa")]
        [DataType(DataType.Text)]
        [Remote("CheckUniqueRoom", "RoomAdmin", "Account", ErrorMessage="Nazwa musi być unikalna")]        
        public string Title { get; set; }

        [MaxLength(128, ErrorMessage = "Maksykalna długość pola to 128 znaków")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Opis")]
        public string Description { get; set; }
    }
}