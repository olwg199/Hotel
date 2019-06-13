using Hotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Hotel.Web.Models.Shared;

namespace Hotel.Web.Models.Reservation
{
    public class CreateReservationVm
    {
        [Required]
        [Display(Name = "Тип номера")]
        public RoomTypeVm RoomType { get; set; }

        [Required]
        [Display(Name = "Дата заселения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalDate { get; set; }

        [Required]
        [Display(Name = "Дата выезда")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }

        [Required]
        [Display(Name = "Стоимость")]
        public decimal TotalPrice { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; }
    }
}