using MedicalSystemWebApp.DAL;
using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.BLL
{
    public class PatientManager
    {
        PatientGateway patientGateway = new PatientGateway();

        public int SavePatient(Patient patient)
        {
            return patientGateway.SavePatient(patient);
        }
        public Patient GetPatientById(int id)
        {
            return patientGateway.GetPatientById(id);
        }
        public void ValidationFunction(Patient patient)
        {
            if (!IsPresent(patient.Name))
            {
                throw new Exception("Name can't be empty.");
            }
            if (!IsPresent(patient.DOB.ToString()))
            {
                throw new Exception("Date of Birth can't be empty.");
            }
            if (!IsPresent(patient.Mobile))
            {
                throw new Exception("Mobile can't be empty.");
            }
            if (!IsPresent(patient.Name))
            {
                throw new Exception("Name ca't be empty.");
            }
        }
        private bool IsPresent(string value)
        {
            return value.Length > 0;
        }
    }
}