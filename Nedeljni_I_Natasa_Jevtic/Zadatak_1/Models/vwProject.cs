//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwProject
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ClientName { get; set; }
        public System.DateTime ContractDate { get; set; }
        public int ContractManager { get; set; }
        public System.DateTime ProjectStartDate { get; set; }
        public System.DateTime ProjectDeadline { get; set; }
        public decimal HourlyRate { get; set; }
        public string Realization { get; set; }
        public int LeaderId { get; set; }
    }
}