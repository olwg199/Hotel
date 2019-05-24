using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.WEB.Models.Account
{
    public class Registration
    {
        [Required(ErrorMessage = "Поле электронной почты обязательно для заполнения")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пароля обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле подтверждения пароля обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Поле логина обязательно для заполнения")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле имени обязательно для заполнения")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
    }
}