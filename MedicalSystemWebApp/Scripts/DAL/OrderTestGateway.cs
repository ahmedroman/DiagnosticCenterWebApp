using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.DAL
{
    public class OrderTestGateway:CommonGateway
    {
        public int SaveOrderTest(OrderTest orderTest)
        {
            string query = String.Format("INSERT INTO OrderTest VALUES({0}, {1})",
                orderTest.OrderId, orderTest.TestId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
    }
}