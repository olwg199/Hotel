using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Web.Areas.Admin.Models
{
    public class RoomDetailsVm
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }
        
        public int RoomTypeId { get; set; }

        public int BedsCount { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; }
    }
}