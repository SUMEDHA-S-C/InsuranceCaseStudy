//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insurance.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_participants
    {
        public int participantNo { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public Nullable<int> participantTypeNo { get; set; }
    
        public virtual tbl_participantType tbl_participantType { get; set; }
    }
}