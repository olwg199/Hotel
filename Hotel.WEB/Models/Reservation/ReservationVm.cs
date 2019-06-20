using Hotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.WEB.Models.Reservation
{
    public class ReservationVm
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public RoomDto Room { get; set; }

        [Display(Name = "Тип номера")]
        public RoomTypeDto RoomType { get; set; }

        [Display(Name = "Сумма")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Заселение")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Выселение")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Статус")]
        public StatusDto Status { get; set; }
    }
}