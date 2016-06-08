using MedicalSystemWebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.DAL
{
    public class ViewGateway:CommonGateway
    {
        public List<ViewTestWithTestType> GetAllTestWithType()
        {
            List<ViewTestWithTestType> testWithTypeList = new List<ViewTestWithTestType>();
            string query = "SELECT * FROM ViewTestWithTestType";
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ViewTestWithTestType testWithType = new ViewTestWithTestType();
                    testWithType.TestId = Convert.ToInt32(reader["TestId"]);
                    testWithType.TestName = reader["TestName"].ToString();
                    testWithType.Fee = Convert.ToSingle(reader["Fee"]);
                    testWithType.TestTypeId = Convert.ToInt32(reader["TestTypeId"]);
                    testWithType.TestTypeName = reader["TestTypeName"].ToString();
                    testWithTypeList.Add(testWithType);
                }
            }
            reader.Close();
            conn.Close();
            return testWithTypeList;
        }
        public List<ViewOrderWithDate> GetOrderWithDate(DateTime fromDate, DateTime toDate, string columnName)
        {
            List<ViewOrderWithDate> orderWithDateList = new List<ViewOrderWithDate>();
            string query = String.Format("SELECT * FROM ViewOrderWithDate WHERE EntryDate BETWEEN '{0}' AND '{1}' ORDER BY '{2}'",
                fromDate, toDate, columnName);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    ViewOrderWithDate orderWithDate = new ViewOrderWithDate();
                    orderWithDate.TestId = Convert.ToInt32(reader["TestId"]);
                    orderWithDate.TestName = reader["TestName"].ToString();
                    orderWithDate.Fee = Convert.ToSingle(reader["Fee"]);
                    orderWithDate.TestTypeId = Convert.ToInt32(reader["TestTypeId"]);
                    orderWithDate.TestTypeName = reader["TestTypeName"].ToString();
                    orderWithDate.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    orderWithDateList.Add(orderWithDate);
                }
            }
            reader.Close();
            conn.Close();
            return orderWithDateList;
        }
        public List<ViewOrderWithPatient> GetUnpaidBillWithPatient(DateTime fromDate, DateTime toDate)
        {
            List<ViewOrderWithPatient> orderWithPatientList = new List<ViewOrderWithPatient>();
            string query = String.Format("SELECT * FROM ViewOrderWithPatient WHERE TotalFee > 0 AND EntryDate BETWEEN '{0}' AND '{1}' ORDER BY PatientName",
                fromDate, toDate);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewOrderWithPatient orderWithPatient = new ViewOrderWithPatient();
                    orderWithPatient.OrderId = Convert.ToInt32(reader["OrderId"]);
                    orderWithPatient.BillNo = reader["BillNo"].ToString();
                    orderWithPatient.TotalFee = Convert.ToSingle(reader["TotalFee"]);
                    orderWithPatient.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    orderWithPatient.PatientId = Convert.ToInt32(reader["PatientId"]);
                    orderWithPatient.PatientName = reader["PatientName"].ToString();
                    orderWithPatient.Mobile = reader["Mobile"].ToString();
                    orderWithPatientList.Add(orderWithPatient);
                }
            }
            reader.Close();
            conn.Close();
            return orderWithPatientList;
        }
        public List<ViewOrderWithPatient> GetPatientByBill(string billNo)
        {
            List<ViewOrderWithPatient> patientWithBillList = new List<ViewOrderWithPatient>();
            string query = String.Format("SELECT * FROM ViewOrderWithPatient WHERE BillNo='{0}'", billNo);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    ViewOrderWithPatient orderWithPatient = new ViewOrderWithPatient();
                    orderWithPatient.OrderId = Convert.ToInt32(reader["OrderId"]);
                    orderWithPatient.BillNo = reader["BillNo"].ToString();
                    orderWithPatient.TotalFee = Convert.ToSingle(reader["TotalFee"]);
                    orderWithPatient.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    orderWithPatient.PatientId = Convert.ToInt32(reader["PatientId"]);
                    orderWithPatient.PatientName = reader["PatientName"].ToString();
                    orderWithPatient.Mobile = reader["Mobile"].ToString();
                    orderWithPatient.DOB = Convert.ToDateTime(reader["DOB"]);
                    patientWithBillList.Add(orderWithPatient);
                }
            }
            reader.Close();
            conn.Close();
            return patientWithBillList;
        }
        public List<ViewOrderWithPatient> GetPatientByMobile(string mobile)
        {
            List<ViewOrderWithPatient> patientWithBillList = new List<ViewOrderWithPatient>();
            string query = String.Format("SELECT * FROM ViewOrderWithPatient WHERE Mobile='{0}'", mobile);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewOrderWithPatient orderWithPatient = new ViewOrderWithPatient();
                    orderWithPatient.OrderId = Convert.ToInt32(reader["OrderId"]);
                    orderWithPatient.BillNo = reader["BillNo"].ToString();
                    orderWithPatient.TotalFee = Convert.ToSingle(reader["TotalFee"]);
                    orderWithPatient.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    orderWithPatient.PatientId = Convert.ToInt32(reader["PatientId"]);
                    orderWithPatient.PatientName = reader["PatientName"].ToString();
                    orderWithPatient.Mobile = reader["Mobile"].ToString();
                    orderWithPatient.DOB = Convert.ToDateTime(reader["DOB"]);
                    patientWithBillList.Add(orderWithPatient);
                }
            }
            reader.Close();
            conn.Close();
            return patientWithBillList;
        }
        public List<ViewOrderWithPatient> GetPatientByName(string patientName)
        {
            List<ViewOrderWithPatient> patientWithBillList = new List<ViewOrderWithPatient>();
            string query = String.Format("SELECT * FROM ViewOrderWithPatient WHERE patientName LIKE '%{0}%'", patientName);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewOrderWithPatient orderWithPatient = new ViewOrderWithPatient();
                    orderWithPatient.OrderId = Convert.ToInt32(reader["OrderId"]);
                    orderWithPatient.BillNo = reader["BillNo"].ToString();
                    orderWithPatient.TotalFee = Convert.ToSingle(reader["TotalFee"]);
                    orderWithPatient.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
                    orderWithPatient.PatientId = Convert.ToInt32(reader["PatientId"]);
                    orderWithPatient.PatientName = reader["PatientName"].ToString();
                    orderWithPatient.Mobile = reader["Mobile"].ToString();
                    orderWithPatient.DOB = Convert.ToDateTime(reader["DOB"]);
                    patientWithBillList.Add(orderWithPatient);
                }
            }
            reader.Close();
            conn.Close();
            return patientWithBillList;
        }
        

    }
}