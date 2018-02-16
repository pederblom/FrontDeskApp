using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class User {

        public string email { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    
        public User()
        {

        }
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

        public int ID { get; set; }
        public int beds { get; set; }
        public int size { get; set; }
        public bool smoker { get; set; }
        public int quality { get; set; }
        public bool available { get; set; }

        public Room()
        {

        }
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
        public int ID { get; set; }
        public int type { get; set; }
        public string comment { get; set; }
        public int status { get; set; }
        public Room room { get; set; }

        public Request()
        {

        }
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
        public int ID { get; set; }
        public Room room { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
        public User user { get; set; }
        public bool confirmed { get; set; }

        public Reservation ()
        {

        }

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
