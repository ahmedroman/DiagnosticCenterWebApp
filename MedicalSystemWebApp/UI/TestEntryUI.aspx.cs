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
    public partial class TestEntryUI : System.Web.UI.Page
    {
        TestTypeManager testTypeManager = new TestTypeManager();
        TestManager testManager = new TestManager();
        ViewManager viewManager = new ViewManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTestTypeDropDiwnLiast();
                LoadTestGridView();
            }
        }

        protected void saveTestButton_Click(object sender, EventArgs e)
        {
            try 
            {
                Test test = new Test();
                test.Name = testNameTextBox.Text;
                test.Fee = Convert.ToSingle(testFeeTextBox.Text);
                try
                {
                    test.TestTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);
                }
                catch (FormatException formatException)
                {
                    messageLabel.Text = "Please select a Type.";
                    return;
                }
                testManager.ValidationFunction(test);
                int affectedRow = testManager.SaveTest(test);
                if (affectedRow > 0)
                {
                    messageLabel.Text = "Test Added successfully.";
                    ClearFields();
                }
                LoadTestGridView();
            }
            catch (FormatException formatException)
            {
                
                messageLabel.Text = "Please enter a valid Number";
            }
            catch(Exception exception)
            {
                messageLabel.Text = exception.Message;
            }
            
        }
        private void ClearFields()
        {
            testNameTextBox.Text = "";
            testFeeTextBox.Text = "";
            testTypeDropDownList.SelectedIndex = 0;
        }
        private void LoadTestTypeDropDiwnLiast()
        {
            testTypeDropDownList.DataSource = testTypeManager.GetAllTestType();
            testTypeDropDownList.DataValueField = "Id";
            testTypeDropDownList.DataTextField = "Name";
            testTypeDropDownList.DataBind();
            testTypeDropDownList.Items.Insert(0, "--Selct Test--");
        }
        private void LoadTestGridView()
        {
            showAllTestGridView.DataSource = viewManager.GetAllTestWithType();
            showAllTestGridView.DataBind();
        }
    }
}