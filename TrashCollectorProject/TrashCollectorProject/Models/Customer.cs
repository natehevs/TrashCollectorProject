using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Suspended")]
        public bool isSuspended { get; set; }
        [DisplayName("Extra Pickup Date")]
        public string extraPickupDate { get; set; }
    }
}