using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WEB.Areas.Admin.Models
{
    public class RoomTypeDetails
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        [Display(Name = "Стоимость")]
        public long Price { get; set; }

        public string PathToImage { get; set; }

        public int[] SelectedConveniences { get; set; }

        public IEnumerable<SelectListItem> AvailableConveniences { get; set; }
    }
}