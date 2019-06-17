using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Web.Areas.Admin.Models
{
    public class RoomDetailsVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Номер комнаты обязателен для заполнения")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Номер комнаты может быть только числом")]
        [Display(Name = "Номер комнаты")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Тип комнаты обязателен для выбора")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Идентификатор типа комнаты может быть только числом")]
        [Display(Name = "Тип комнаты")]
        public int RoomTypeId { get; set; }

        [Display(Name = "Тип номера")]
        public string RoomTypeName { get; set; }

        [Required(ErrorMessage = "Поле количества спальных мест обязательно для заполнения")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Количество спальных мест может быть только числом")]
        [Display(Name = "Количество спальных мест")]
        public int BedsCount { get; set; }

        [Display(Name = "Типы номеров")]
        public IEnumerable<SelectListItem> RoomTypes { get; set; }
    }
}