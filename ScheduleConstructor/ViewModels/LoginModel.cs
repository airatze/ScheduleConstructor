using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleConstructor.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "не указан логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
