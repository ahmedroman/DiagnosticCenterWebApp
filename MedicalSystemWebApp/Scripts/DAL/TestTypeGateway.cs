using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.DAL
{
    public class TestTypeGateway : CommonGateway
    {
        public int SaveTestType(TestType testType)
        {
            string query = String.Format("INSERT INTO TestType VALUES('{0}')", testType.Name);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public List<TestType> GetAllTestType()
        {
            List<TestType> testTypeList = new List<TestType>();
            string query = "SELECT * FROM TestType";
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    TestType testType = new TestType();
                    testType.Id = Convert.ToInt32(reader["Id"]);
                    testType.Name = reader["Name"].ToString(); ;
                    testTypeList.Add(testType);
                }
            }
            reader.Close();
            conn.Close();
            return testTypeList;
        }
        public TestType GetTestTypeByName(string name)
        {
            TestType testType = null;
            string query = String.Format("SELECT * FROM TestType WHERE Name='{0}'",name);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    testType = new TestType();
                    testType.Id = Convert.ToInt32(reader["Id"]);
                    testType.Name = reader["Name"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return testType;
        }

    }
}