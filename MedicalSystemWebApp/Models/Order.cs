using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string BillNo { get; set; }
        public DateTime EntryDate { get; set; }
        public int PatientId { get; set; }
        public float TotalFee { get; set; }
    }
}