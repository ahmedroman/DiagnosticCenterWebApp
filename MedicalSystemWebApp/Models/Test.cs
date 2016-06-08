using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Fee { get; set; }
        public int TestTypeId { get;set; }

        public string testToString()
        {
            return Id + "|" + Name + "|" + Fee; 
        }
    }
}