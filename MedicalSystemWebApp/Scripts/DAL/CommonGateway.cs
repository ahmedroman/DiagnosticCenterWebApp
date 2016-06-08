using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MedicalSystemWebApp.DAL
{
    public class CommonGateway
    {
        string connectionString = 
            WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected SqlConnection conn;
        protected SqlCommand command;
        public CommonGateway()
        {
            conn = new SqlConnection(connectionString);
        }

    }
}