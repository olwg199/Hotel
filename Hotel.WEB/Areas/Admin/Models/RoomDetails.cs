using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WEB.Areas.Admin.Models
{
    public class RoomDetails
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }
        
        public int RoomTypeId { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; }
    }
}