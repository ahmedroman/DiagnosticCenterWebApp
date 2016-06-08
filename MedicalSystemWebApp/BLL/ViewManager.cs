using MedicalSystemWebApp.DAL;
using MedicalSystemWebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.BLL
{
    public class ViewManager
    {
        ViewGateway viewGateway = new ViewGateway();

        public List<ViewTestWithTestType> GetAllTestWithType()
        {
            return viewGateway.GetAllTestWithType();
        }
        public List<ViewOrderWithDate> GetOrderWithDate(DateTime fromDate, DateTime toDate, string columnName)
        {
            return viewGateway.GetOrderWithDate(fromDate, toDate, columnName);
        }
        public List<ViewOrderWithPatient> GetUnpaidBillWithPatient(DateTime fromDate, DateTime toDate)
        {
            return viewGateway.GetUnpaidBillWithPatient(fromDate, toDate);
        }
        public List<ViewOrderWithPatient> GetPatientByBill(string billNo)
        {
            return viewGateway.GetPatientByBill(billNo);
        }
        public List<ViewOrderWithPatient> GetPatientByMobile(string mobile)
        {
            return viewGateway.GetPatientByMobile(mobile);
        }
        public List<ViewOrderWithPatient> GetPatientByName(string patientName)
        {
            return viewGateway.GetPatientByName(patientName);
        }


        public void ValidationFunction(DateTime fromDate, DateTime toDate)
        {
            if (!IsPresent(fromDate.ToString()))
            {
                throw new Exception("From date can't be empty");
            }
            if (!IsPresent(toDate.ToString()))
            {
                throw new Exception("To date can't be empty");
            }
            if ((toDate - fromDate).TotalDays < 0)
            {
                throw new Exception("From date cant be bigger than to date");
            }
        }
        public void SearchedTextValidation(string value)
        {
            if (!IsPresent(value))
            {
                throw new Exception("Searched value can't be empty");
            }
            
        }
        public void PaymentValidation(float amount, float dueAmount)
        {
            if (amount < 1)
            {
                throw new Exception("Amount must be greated than 0.");
            }
            if (dueAmount < amount)
            {
                throw new Exception("Amount must be smaller or equal than due Amount.");            
            }
        }

        private bool IsPresent(string value)
        {
            return value.Length > 0;
        }

    }
}