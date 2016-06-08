using MedicalSystemWebApp.BLL;
using MedicalSystemWebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalSystemWebApp.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        ViewManager viewManager = new ViewManager();
        List<ViewOrderWithPatient> patientList = new List<ViewOrderWithPatient>();

        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel.Text = "";
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            try 
            {
                string searchedValue = searchTextBox.Text;
                viewManager.SearchedTextValidation(searchedValue);
                if (billNoRadiBbutton.Checked)
                {
                    patientList = viewManager.GetPatientByBill(searchedValue);
                }
                else if (mobileRadioButton.Checked)
                {
                    patientList = viewManager.GetPatientByMobile(searchedValue);
                }
                else if (nameRadioButton.Checked)
                {
                    patientList = viewManager.GetPatientByName(searchedValue);
                }
                else 
                {
                    messageLabel.Text = "Please Select an item";
                    return;
                }
                if (!LoadPatientToGridView())
                {
                    messageLabel.Text = "Nothing Found.";
                }
                else 
                {
                    //item found
                    messageLabel.Text = patientList.Count + " item found.";
                }
            }
            catch(Exception exception)
            {
                messageLabel.Text = exception.Message;
            }
        }
        private bool LoadPatientToGridView()
        {
            if (patientList.Count > 0) 
            {
                showAllInfoGridView.DataSource = patientList;
                showAllInfoGridView.DataBind();
                return true;
            }
            return false;
        }
    }
}