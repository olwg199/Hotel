using System.Collections.Generic;
using Hotel.WEB.Models.Reservation;

namespace Hotel.WEB.Models.Home
{
    public class ProfileVm
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public IEnumerable<ReservationVm> Reservations { get; set; }
    }
}