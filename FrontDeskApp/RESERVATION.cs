//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrontDeskApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESERVATION
    {
        public int res_ID { get; set; }
        public Nullable<int> room_nr { get; set; }
        public System.DateTime check_in_date { get; set; }
        public System.DateTime check_out_date { get; set; }
        public string e_mail { get; set; }
        public bool confirmed { get; set; }
    
        public virtual ROOM ROOM { get; set; }
        public virtual USER USER { get; set; }
    }
}
