using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.WEB.Models.Reservation;

namespace Hotel.WEB.Models.Home
{
    public class ProfileVm
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Вы не ввели логин")]
        [DataType(DataType.Text)]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле электронной почты обязательно для заполнения")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        public IEnumerable<ReservationVm> Reservations { get; set; }
    }
}