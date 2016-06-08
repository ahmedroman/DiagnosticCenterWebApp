using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.DAL
{
    public class TestGateway:CommonGateway
    {
        public int SaveTest(Test test)
        {
            string query = String.Format("INSERT INTO Test VALUES('{0}', {1}, {2})",
                test.Name, test.Fee, test.TestTypeId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public Test GetTestByName(string name)
        {
            Test test = null;
            string query = String.Format("SELECT * FROM Test WHERE Name='{0}'", name);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    test = new Test();
                    test.Id = Convert.ToInt32(reader["Id"]);
                    test.Name = reader["Name"].ToString();
                    test.Fee = Convert.ToSingle(reader["Fee"]);
                    test.TestTypeId = Convert.ToInt32(reader["TestTypeId"]);
                }
            }
            reader.Close();
            conn.Close();
            return test;
        }
        public List<Test> GetAllTest()
        {
            List<Test> testList = new List<Test>();
            string query = String.Format("SELECT * FROM Test");
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Test test = new Test();
                    test.Id = Convert.ToInt32(reader["Id"]);
                    test.Name = reader["Name"].ToString();
                    test.Fee = Convert.ToSingle(reader["Fee"]);
                    test.TestTypeId = Convert.ToInt32(reader["TestTypeId"]);
                    testList.Add(test);
                }
            }
            reader.Close();
            conn.Close();
            return testList;
        }
    }
}