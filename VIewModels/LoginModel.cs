using System.ComponentModel.DataAnnotations;

namespace WebApplication1.VIewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Name { get; set; }
     
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}