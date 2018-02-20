using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FrontDeskApp
{
    class FrontDeskController
    {
        public HotelEntities dx = new HotelEntities();
        public FrontDeskController()
        {
            
        }

        public HotelEntities getDbContext() {
            return dx;
        }

        public void addReservation(int res_ID, DateTime checkIn_Date, DateTime checkOut_Date, string e_mail)
        {
            RESERVATION res = new RESERVATION();
            res.res_ID = res_ID;
            res.checkIn_Date = checkIn_Date;
            res.checkOut_Date = checkOut_Date;
            res.e_mail = e_mail;
            res.confirmed = false;

            dx.RESERVATIONs.Add(res);

            dx.SaveChanges();
        }

        public void deleteReservation(int res_ID)
        {
            RESERVATION res = dx.RESERVATIONs.Where(r => r.res_ID == res_ID).First();

            dx.RESERVATIONs.Remove(res);

            dx.SaveChanges();
        }

        public void associateReservation(ROOM room, RESERVATION res)
        {
            res.ROOM = room;

            dx.SaveChanges();
        }

        public ROOM findRoom(int roomnumber)
        {
            ROOM room = dx.ROOMs.Where(r => r.room_ID == roomnumber).First();
            return room;
        }

        public RESERVATION findReservation(int res_ID)
        {
            RESERVATION res = dx.RESERVATIONs.Where(r => r.res_ID == res_ID).First();
            return res;
        }

    }
}
