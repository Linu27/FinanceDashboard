//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanceDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ComponentModel.DataAnnotations;
    [DataContract]
    public partial class ConsumerTable
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public System.DateTime DateofBirth { get; set; }
        [DataMember]
        public long PhoneNo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        [Compare("Password")]
        public string Confirmpassword { get; set; }
        [DataMember]
        public string CardType { get; set; }
        [DataMember]
        public string SelectBank { get; set; }
        [DataMember]
        public string IFSC_Code { get; set; }
        [DataMember]
        public Nullable<long> AccountNumber { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual CardTypeTable CardTypeTable { get; set; }
        public virtual OTP_Validation OTP_Validation { get; set; }
    }
}
