using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;

namespace FrontDeskApp
{
    class FrontDeskAppModel
    {
        public DbContext dx = new DbContext("Data Source=DESKTOP-U4HAM0I;Initial Catalog=DAT154;Integrated Security=True");
        public DbSet<RESERVATION> reservations { get; }
        public DbSet<REQUEST> requests { get;  }
        public DbSet<ROOM> rooms { get; }
        public DbSet<USER> users { get; }

        public FrontDeskAppModel() {
            reservations = dx.Set<RESERVATION>();
            rooms = dx.Set<ROOM>();
            requests = dx.Set<REQUEST>();
            users = dx.Set<USER>();

        }

        public void addReservation(int res_ID, DateTime checkIn_Date, DateTime checkOut_Date, string e_mail)
        {
            RESERVATION res = new RESERVATION();
            res.res_ID = res_ID;
            res.checkIn_Date = checkIn_Date;
            res.checkOut_Date = checkOut_Date;
            res.e_mail = e_mail;
            res.confirmed = false;

            reservations.Add(res);

            dx.SaveChanges();
        }

        public void deleteReservation(int res_ID)
        {
            RESERVATION res = reservations.Where(r => r.res_ID == res_ID).First();

            reservations.Remove(res);

            dx.SaveChanges();
        }

        public void associateReservation(ROOM room, int res_ID)
        {
            RESERVATION res = reservations.Where(r => r.res_ID == res_ID).First();
            res.ROOM = room;

            dx.SaveChanges();
        }
    }
}
