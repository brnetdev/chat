using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chat.FE.Web.Areas.Account.Models
{

    public class AddUserNamePasswordVm
    {
        [MinLength(4, ErrorMessage="Minimalna długość pola Login to 4 znaki")]
        [Required(ErrorMessage = "Pola Loigin jest wymagane")]
        [Display(Name ="Login")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [MinLength(4, ErrorMessage ="Minimalna długość hasła to 4 znaki")]
        [Required(ErrorMessage ="Pola hasło jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Pola haseł muszą być takie same")]
        [Display(Name = "Powtórz hasło")]
        [DataType(DataType.Password)]
        [Required]
        public string RenewPassword { get; set; }
    }
}
