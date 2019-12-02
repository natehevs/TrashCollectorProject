using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollectorProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [DisplayName("Street Address")]
        public string streetAddress { get; set; }
        [DisplayName("City")]
        public string city { get; set; }
        [DisplayName("State")]
        public string state { get; set; }
        [DisplayName("Zipcode")]
        public int zipcode { get; set; }
        [DisplayName("Pickup Day")]
        public string pickupDay { get; set; }
        [DisplayName("Balance")]
        public double balance { get; set; }
        [DisplayName("Suspended Start Date (MM/DD/YYYY)")]
        public string startSuspended { get; set; }
        [DisplayName("Suspended End Date (MM/DD/YYYY)")]
        public string endSuspended { get; set; }
        [DisplayName("Extra Pickup Date(MM/DD/YYYY)")]
        public string extraPickupDate { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}