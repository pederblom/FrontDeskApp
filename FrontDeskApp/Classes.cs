using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class User {

        string email;
        string password;
        string firstname;
        string lastname;
    
        public User (string email, string password, string firstname, string lastname)
        {
            this.email = email;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
        }
    }

    class Room
    {

        int ID;
        int beds;
        int size;
        bool smoker;
        int quality;
        bool available;

        public Room(int ID, int beds, int size, bool smoker, int quality, bool available)
        {
            this.ID = ID;
            this.beds = beds;
            this.size = size;
            this.smoker = smoker;
            this.quality = quality;
            this.available = available;
        }
    }

    class Request
    {
        int ID;
        int type;
        string comment;
        int status;
        Room room;

        public Request (int ID, int type, string comment, int status, Room room)
        {
            this.ID = ID;
            this.type = type;
            this.comment = comment;
            this.status = status;
            this.room = room;
        }

    }

    class Reservation
    {
        int ID;
        Room room;
        DateTime checkin;
        DateTime checkout;
        User user;
        bool confirmed;

        public Reservation (int ID, Room room, DateTime checkin, DateTime checkout, User user, bool confirmed)
        {
            this.ID = ID;
            this.room = room;
            this.checkin = checkin;
            this.checkout = checkout;
            this.user = user;
            this.confirmed = confirmed;
        }
    }
}
