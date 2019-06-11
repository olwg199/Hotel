using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Web.Areas.Admin.Models
{
    public class RoomTypeDetailsVm
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        [Display(Name = "Стоимость")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string PathToImage { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public int[] SelectedConveniences { get; set; }

        public IEnumerable<SelectListItem> AvailableConveniences { get; set; }
    }
}