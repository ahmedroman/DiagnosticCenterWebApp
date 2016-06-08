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
    public partial class TestRequestEntryUI : System.Web.UI.Page
    {
        List<Test> testList = new List<Test>();

        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            if (!IsPostBack)
            {
                LoadLoadTestDropDown();
                LoatAllTestToHiddenField();                
            }
        }

        Test test = new Test();
        TestManager testManager = new TestManager();

        private void LoadLoadTestDropDown()
        {
            testList = testManager.GetAllTest();
            testDropDownList.DataSource = testList;
            testDropDownList.DataValueField = "Id";
            testDropDownList.DataTextField = "Name";
            testDropDownList.DataBind();
            testDropDownList.Items.Insert(0, "--Select Test--");
        }
        PatientManager patientManager = new PatientManager();
        OrderManager orderManager = new OrderManager();
        OrderTestManager orderTestManager = new OrderTestManager();
        protected void saveTestsButton_Click(object sender, EventArgs e)
        {
            try 
            {
                Patient patient = new Patient();
                patient.Name = patientNameTextBox.Text;
                patient.DOB = Convert.ToDateTime(DOBTextBox.Text);
                patient.Mobile = patientMobileTextBox.Text;
                patientManager.ValidationFunction(patient);
                int patientId = patientManager.SavePatient(patient);

                Order order = new Order();
                order.BillNo = orderManager.GenerateBillNo();
                order.EntryDate = DateTime.Now;
                order.PatientId = patientId;
                order.TotalFee = Convert.ToSingle(totalFeeHiddenField.Value);
                int orderId = orderManager.SaveOrder(order);

                int affectedRow = 0;
                List<Test> addedTestList = HiddenFieldToList();
                if (addedTestList.Count > 0)
                {
                    foreach (Test atest in addedTestList)
                    {
                        OrderTest orderTest = new OrderTest();
                        orderTest.OrderId = orderId;
                        orderTest.TestId = atest.Id;
                        affectedRow = orderTestManager.SaveOrderTest(orderTest);
                    }
                }
                if (affectedRow > 0)
                {
                    messageLabel.Text = "Test added successfully.";
                    if (Session["Patient"] != null)
                    {
                        Session["Patient"] = null;
                    }
                    if (Session["TestList"] != null)
                    {
                        Session["TestList"] = null;
                    }
                    if (Session["Order"] != null)
                    {
                        Session["Order"] = null;
                    }
                    Session["Patient"] = patient;
                    Session["TestList"] = addedTestList;
                    Session["Order"] = order;
                    Response.Redirect("PdfFormatUI.aspx");
                    ClearFields();
                }
                
            }
            catch(Exception exception)
            {
                messageLabel.Text = exception.Message;
            }

        }

        private List<Test> HiddenFieldToList()
        {
            List<Test> testList = new List<Test>();
            string allTest = addedTestHiddenField.Value;
            string[] allTestArray = allTest.Split(',');
            for (int i = 0; i < allTestArray.Length - 1; i++)
            {
                string[] testArray = allTestArray[i].Split('|');
                Test test = new Test();
                test.Id = Convert.ToInt32(testArray[0]);
                test.Name = testArray[1];
                test.Fee = Convert.ToSingle(testArray[2]);
                testList.Add(test);
            }
            return testList;
        }
        private void LoatAllTestToHiddenField()
        {
            string allTesttoString = "";
            foreach(Test test in testList)
            {
                allTesttoString += test.testToString() + ",";
            }
            allTestHiddenField.Value = allTesttoString;
        }
        private void ClearFields()
        {
            patientNameTextBox.Text = "";
            DOBTextBox.Text = "";
            patientMobileTextBox.Text = "";
            testDropDownList.SelectedIndex = 0;
        }
    }
}
