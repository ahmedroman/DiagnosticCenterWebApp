using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.Models.View
{
    public class ViewOrderWithPatient
    {
        public int OrderId{ get; set; }
        public string BillNo{ get; set; }
        public float TotalFee{ get; set; }
        public DateTime EntryDate { get; set; }
        public int PatientId{ get; set; }
        public string PatientName{ get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
    }
}