using MedicalSystemWebApp.BLL;
using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalSystemWebApp.UI
{
    public partial class PayBillUI : System.Web.UI.Page
    {
        ViewManager viewManager = new ViewManager();
        OrderManager orderManager = new OrderManager();
        Order order;
        PatientManager patientManager = new PatientManager();
        Patient patient;

        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            if (!IsPostBack) 
            {
                if (Request.QueryString["Id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["Id"]);
                    LoadOrder(id);
                    LoadPatient(order.PatientId);
                }
            }
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            try 
            {
                float payAmount = Convert.ToSingle(payBillTextBox.Text);
                float dueAmount = Convert.ToSingle(dueAmountLabel.Text);
                viewManager.PaymentValidation(payAmount, dueAmount);
                order = new Order();
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                order.Id = id;
                order.TotalFee = dueAmount - payAmount;
                int affectedRow = orderManager.PayTheBill(order);
                if (affectedRow > 0)
                {
                    messageLabel.Text = "Paid successfully .";
                    LoadOrder(id);
                }
            }
            catch(FormatException formatException)
            {
                messageLabel.Text = "Invalid Number";
            }
            catch(Exception exception)
            {
                messageLabel.Text = exception.Message;
            }
        }
        private void LoadPatient(int patientId)
        {
            patient = patientManager.GetPatientById(patientId);
            patientNameLabel.Text = patient.Name;
            DOBLabel.Text = patient.DOB.ToString("dd MMMM yyyy");
            patientMobileLabel.Text = patient.Mobile;
        }
        private void LoadOrder(int orderId)
        {
            order = orderManager.GetOrderById(orderId);
            dueAmountLabel.Text = order.TotalFee.ToString();
            dayPassedLabel.Text = Convert.ToInt32((DateTime.Now- order.EntryDate).TotalDays).ToString();
        }
    }
}
