using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;
using System.Data;
using System.Windows.Controls;

namespace FrontDeskApp
{
    class FrontDeskController
    {
        public DAT154Entities dx = new DAT154Entities();
        public FrontDeskController()
        {
            
        }

        public ObservableCollection<ROOM> GetRooms() {

            dx.ROOMs.Load();

            return dx.ROOMs.Local;
        }

        public ObservableCollection<RESERVATION> GetReservations()
        {

            dx.RESERVATIONs.Load();

            return dx.RESERVATIONs.Local;
        }

        public ObservableCollection<ROOM> GetRoomsForReservation(string res_ID)
        {
            dx.ROOMs.Load();

            ObservableCollection<ROOM> freeRooms = new ObservableCollection<ROOM>();
            RESERVATION res = findReservation(res_ID);
            if (res != null)
            {
                string quality = res.ROOM.quality;
                int nr_beds = res.ROOM.nr_beds;
                DateTime checkin = res.check_in_date;
                DateTime checkout = res.check_out_date;

                var rooms = dx.ROOMs.Where(r => r.quality == quality && r.nr_beds == nr_beds);
                foreach (var r in rooms)
                {
                    if (r.RESERVATIONs.Where(rese => rese.check_in_date > checkin && rese.check_in_date < checkout) != null)
                        freeRooms.Add(r);
                }
            }
            return freeRooms;
        }

        //public ObservableCollection<ROOM>

        public void addReservation(string room_nr, string checkIn_Date, string checkOut_Date, string e_mail)
        {
            RESERVATION res = new RESERVATION();
            DateTime checkin = DateTime.ParseExact(checkIn_Date, "dd/MM/yy", CultureInfo.InvariantCulture);
            DateTime checkout = DateTime.ParseExact(checkOut_Date, "dd/MM/yy", CultureInfo.InvariantCulture);
            res.room_nr = Int32.Parse(room_nr);
            res.check_in_date = checkin;
            res.check_out_date = checkout;
            res.e_mail = e_mail;
            res.confirmed = false;

            dx.RESERVATIONs.Add(res);

            dx.SaveChanges();
        }

        public void CheckOut(string res_ID)
        {
            int resID = Int32.Parse(res_ID);
            RESERVATION res = dx.RESERVATIONs.Where(r => r.res_ID == resID).First();
            if (res != null)
            {
                res.ROOM.available = true;
                CreateRequest("Cleaning", "Check Out cleaning", res.ROOM.room_ID.ToString());
                deleteReservation(res);
            }
        }

        public void deleteReservation(RESERVATION res)
        {
            dx.RESERVATIONs.Remove(res);

            dx.SaveChanges();
        }

        public void associateReservation(string room_nr, RESERVATION res)
        {
            res.ROOM = findRoom(room_nr);
            res.confirmed = true;
            res.ROOM.available = false;
            dx.SaveChanges();
        }

        public ROOM findRoom(string roomnumber)
        {
            int roomID = Int32.Parse(roomnumber);
            ROOM room = dx.ROOMs.Where(r => r.room_ID == roomID).First();
            return room;
        }

        public RESERVATION findReservation(string res_ID)
        {
            int resID = Int32.Parse(res_ID);
            RESERVATION res = dx.RESERVATIONs.Where(r => r.res_ID == resID).First();
            return res;
        }

        public void CreateRequest(string type, string comment, string room_nr)
        {
            REQUEST req = new REQUEST();
            req.type = type;
            req.comment = comment;
            req.status = "New";
            req.ROOM = findRoom(room_nr);

            dx.REQUESTs.Add(req);

            dx.SaveChanges();
        }

        public RESERVATION GetReservation(ListView ReservationList)
        {
            RESERVATION info = (RESERVATION)ReservationList.SelectedItems[0];
            return info;
        }

        public int GetRoom(ListView RoomList)
        {
            ROOM room = (ROOM)RoomList.SelectedItems[0];
            return room.room_ID;
        }

    }

}
