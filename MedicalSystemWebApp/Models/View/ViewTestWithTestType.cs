using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.Models.View
{
    public class ViewTestWithTestType
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public float Fee { get; set; }
        public int TestTypeId { get;set; }
        public string TestTypeName { get; set; }
    }
}