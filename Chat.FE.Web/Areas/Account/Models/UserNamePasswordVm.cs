using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Areas.Account.Models
{

    public class UserNamePasswordVm
    {        
        [Required(ErrorMessage = "Pola Loigin jest wymagane")]
        [Display(Name = "Login")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
                
        [Required(ErrorMessage = "Pola hasło jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
