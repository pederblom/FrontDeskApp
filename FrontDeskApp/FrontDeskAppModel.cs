using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp
{
    class FrontDeskAppModel
    {
        FrontDeskAppModel() { }

        DbContext dx = new DbContext("Data Source=DESKTOP-U4HAM0I;Initial Catalog=DAT154;Integrated Security=True");
        DbSet<USER> users;
        var rooms = dx.Set<ROOM>;
        var requests = dx.Set<REQUEST>();
        var reservations = dx.Set<RESERVATION>();
    }
}
