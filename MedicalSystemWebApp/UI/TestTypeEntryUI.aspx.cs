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
    public partial class TestTypeEntryUI : System.Web.UI.Page
    {
        TestTypeManager testTypeManager = new TestTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            LoadGridView();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try 
            {
                TestType testType = new TestType();
                testType.Name = testTypeTextBox.Text;
                testTypeManager.ValidationFunction(testType);
                int affecedRow = testTypeManager.SaveTestType(testType);

                if (affecedRow > 0)
                {
                    messageLabel.Text = "TestTypeadded successfully.";
                }
                LoadGridView();
                ClearData();

            }
            catch(Exception exception)
            {
                messageLabel.Text = exception.Message;
            }
        }
        private void LoadGridView()
        {
            showAlltestTypeGridView.DataSource = testTypeManager.GetAllTestType();
            showAlltestTypeGridView.DataBind();
        }
        private void ClearData()
        {
            testTypeTextBox.Text = "";
        }
    }
}