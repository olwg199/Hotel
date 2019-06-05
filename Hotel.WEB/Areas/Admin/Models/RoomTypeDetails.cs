using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WEB.Areas.Admin.Models
{
    public class RoomTypeDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BedsCount { get; set; }

        public long Price { get; set; }

        public int[] SelectedConveniences { get; set; }

        public IEnumerable<SelectListItem> AvailableConveniences { get; set; }
    }
}