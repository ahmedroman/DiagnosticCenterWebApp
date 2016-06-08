using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.DAL
{
    public class OrderGateway:CommonGateway
    {
        public int SaveOrder(Order order)
        {
            string query = String.Format("INSERT INTO [Order] VALUES('{0}', '{1}', {2}, {3});SELECT Scope_Identity();",
                order.BillNo, order.EntryDate, order.PatientId, order.TotalFee);
            command = new SqlCommand(query, conn);
            conn.Open();
            int orderId = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return orderId;
        }
        public Order GetOrderByBillNo(string billNo)
        {
            Order order = null;
            string query = String.Format("SELECT * FROM [Order] WHERE BillNo='{0}'", billNo);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    order = new Order();
                    order.Id = Convert.ToInt32(reader["Id"]);
                    order.BillNo = reader["BillNo"].ToString();
                    order.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    order.PatientId = Convert.ToInt32(reader["PatientId"]);
                }
            }
            reader.Close();
            conn.Close();
            return order;
        }
        public Order GetOrderById(int id)
        {
            Order order = null;
            string query = String.Format("SELECT * FROM [Order] WHERE Id={0}", id);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    order = new Order();
                    order.Id = Convert.ToInt32(reader["Id"]);
                    order.BillNo = reader["BillNo"].ToString();
                    order.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    order.PatientId = Convert.ToInt32(reader["PatientId"]);
                    order.TotalFee = Convert.ToSingle(reader["TotalFee"]);
                }
            }
            reader.Close();
            conn.Close();
            return order;
        }
       
        public int PayTheBill(Order order)
        {
            string query = String.Format("UPDATE [Order] SET TotalFee={0} WHERE Id={1}", 
                order.TotalFee, order.Id);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }

    }
}