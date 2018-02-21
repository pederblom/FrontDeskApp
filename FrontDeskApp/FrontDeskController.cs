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
        public HotelEntities dx = new HotelEntities();
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
                int quality = res.ROOM.quality;
                int nr_beds = res.ROOM.nr_beds;
                DateTime checkin = res.checkIn_Date;
                DateTime checkout = res.checkOut_Date;

                var rooms = dx.ROOMs.Where(r => r.quality == quality && r.nr_beds == nr_beds);
                foreach (var r in rooms)
                {
                    if (r.RESERVATIONs.Where(rese => rese.checkIn_Date >= checkin && rese.checkIn_Date <= checkout) != null)
                        freeRooms.Add(r);
                }
            }
            return freeRooms;
        }

        public void addReservation(string res_ID, string checkIn_Date, string checkOut_Date, string e_mail)
        {
            RESERVATION res = new RESERVATION();
            DateTime checkin = DateTime.ParseExact(checkIn_Date, "dd/MM/yy", CultureInfo.InvariantCulture);
            DateTime checkout = DateTime.ParseExact(checkOut_Date, "dd/MM/yy", CultureInfo.InvariantCulture);
            res.res_ID = Int32.Parse(res_ID);
            res.checkIn_Date = checkin;
            res.checkOut_Date = checkout;
            res.e_mail = e_mail;
            res.confirmed = false;

            dx.RESERVATIONs.Add(res);

            dx.SaveChanges();
        }

        public void CheckOut(string res_ID)
        {
            RESERVATION res = dx.RESERVATIONs.Where(r => r.res_ID == Int32.Parse(res_ID)).First();
            if (res != null)
            {
                res.ROOM.available = true;
                createRequest("Cleaning", "Check Out cleaning", res.ROOM.room_ID.ToString());
                deleteReservation(res_ID);
            }
        }

        public void deleteReservation(string res_ID)
        {
            RESERVATION res = findReservation(res_ID);

            dx.RESERVATIONs.Remove(res);

            dx.SaveChanges();
        }

        public void associateReservation(string room_nr, RESERVATION res)
        {
            res.ROOM = findRoom(room_nr);

            dx.SaveChanges();
        }

        public ROOM findRoom(string roomnumber)
        {
            ROOM room = dx.ROOMs.Where(r => r.room_ID == Int32.Parse(roomnumber)).First();
            return room;
        }

        public RESERVATION findReservation(string res_ID)
        {
            RESERVATION res = dx.RESERVATIONs.Where(r => r.res_ID == Int32.Parse(res_ID)).First();
            return res;
        }

        public void createRequest(string type, string comment, string room_nr)
        {
            REQUEST req = new REQUEST();
            if (type.Equals("Cleaning"))
            {
                req.type = 1;
            } else if (type.Equals("Service"))
            {
                req.type = 2;
            } else
            {
                req.type = 3;
            }
            req.comment = comment;
            req.status = 1;
            req.ROOM = findRoom(room_nr);
        }

        public RESERVATION GetReservation(ListView ReservationList)
        {
            RESERVATION info = null;
            int row = ReservationList.SelectedIndex;
            DataRowView selectedReservation = ReservationList.Items.GetItemAt(row) as DataRowView;
            int reservationID;
            if (selectedReservation != null)
            {
                reservationID = Convert.ToInt16(selectedReservation["Reservation Nr"]);
                //info = Model.GetReservation(reservationID);
            }
            return info;
        }

        public int GetRoom(ListView RoomList)
        {
            int row = RoomList.SelectedIndex;
            DataRowView selectedRoom = RoomList.Items.GetItemAt(row) as DataRowView;
            int roomNr = 0;

            // Trenger exception handling hvis selectedRoom == null
            if (selectedRoom != null)
            {
                roomNr = Convert.ToInt16(selectedRoom["Room Nr"]);
            }
            return roomNr;
        }

    }

}
