//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gDrive
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Comment
    {
        public int id_cmt { get; set; }
        public int id_shop { get; set; }
        public string username { get; set; }
        public System.DateTime date_cmt { get; set; }
        public string comment { get; set; }
    
        public virtual tbl_Shop tbl_Shop { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}