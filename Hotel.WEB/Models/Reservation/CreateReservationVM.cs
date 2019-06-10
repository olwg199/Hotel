using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BLL.DTO;

namespace Hotel.WEB.Models.Reservation
{
    public class CreateReservationVM
    {
        public CreateReservationVM() { }

        public CreateReservationVM(RoomTypeDTO type)
        {
            RoomType = type;
        }

        [Required]
        [Display(Name = "Тип номера")]
        public RoomTypeDTO RoomType { get; set; }

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

        public IEnumerable<SelectListItem> RoomTypes { get; set; }
    }
}