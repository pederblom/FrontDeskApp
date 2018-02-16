using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;

namespace FrontDeskApp
{
    class FrontDeskAppModel
    {
        DbContext dx = new DbContext("Data Source=DESKTOP-U4HAM0I;Initial Catalog=DAT154;Integrated Security=True");

        FrontDeskAppModel() { }

        

        public void getUsers() {
            DbSet<USER> users = dx.Set<USER>();
            
        }
        
        var rooms = dx.Set<ROOM>;
        var requests = dx.Set<REQUEST>();
        var reservations = dx.Set<RESERVATION>();
    }
}
