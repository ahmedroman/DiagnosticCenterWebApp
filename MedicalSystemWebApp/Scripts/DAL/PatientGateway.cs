using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.DAL
{
    public class PatientGateway : CommonGateway
    {
        public int SavePatient(Patient patient)
        {
            string query = String.Format("INSERT INTO Patient(Name, DOB, Mobile) VALUES('{0}', '{1}', '{2}');Select Scope_Identity();",
                patient.Name, patient.DOB, patient.Mobile);
            command = new SqlCommand(query, conn);
            conn.Open();
            int patientId = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return patientId;
        }
        public Patient GetPatientById(int id)
        {
            Patient patient = null;
            string query = String.Format("SELECT * FROM Patient WHERE Id={0}", id);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    patient = new Patient();
                    patient.Id = Convert.ToInt32(reader["Id"]);
                    patient.Name = reader["Name"].ToString();
                    patient.DOB = Convert.ToDateTime(reader["DOB"]);
                    patient.Mobile = reader["Mobile"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return patient;
        }
    }
}