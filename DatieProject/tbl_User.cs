//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatieProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_User
    {
        public tbl_User()
        {
            this.tbl_Comment = new HashSet<tbl_Comment>();
            this.tbl_Rate = new HashSet<tbl_Rate>();
        }
    
        public string username { get; set; }
        public string password { get; set; }
        public System.DateTime reg_date { get; set; }
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
        public bool admin_master { get; set; }
    
        public virtual ICollection<tbl_Comment> tbl_Comment { get; set; }
        public virtual ICollection<tbl_Rate> tbl_Rate { get; set; }
    }
}
