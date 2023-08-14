using NewIceCream.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace NewIceCream.Domain.ViewModels;

public class UserViewModel
{
    [Required(ErrorMessage = "Укажите логин")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Укажите почту")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Повторите пароль")]
    [DataType(DataType.Password)]
    public string UserPassword { get; set; }

    [Required(ErrorMessage = "Повторите пароль")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string UserPasswordConfirm { get; set; }
}

