//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatieAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Rate
    {
        public int id_rate { get; set; }
        public int id_shop { get; set; }
        public string usename { get; set; }
        public double rate { get; set; }
    
        public virtual tbl_Shop tbl_Shop { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}
