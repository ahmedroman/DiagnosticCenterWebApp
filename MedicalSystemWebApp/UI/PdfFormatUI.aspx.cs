using MedicalSystemWebApp.BLL;
using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Net;
using System.Text;

namespace MedicalSystemWebApp.UI
{
    public partial class PdfFormatUI : System.Web.UI.Page
    {
        Patient patient;
        Order order;
        List<Test> testList;
        TestManager testManager = new TestManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            RetriveData();
        }

        protected void generatePdfButton_Click(object sender, EventArgs e)
        {
            generatePdfButton.Visible = false;
            DownloadPdf();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        private void DownloadPdf()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=testRequestEntry.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        private void RetriveData()
        {

            patient = (Patient)Session["Patient"];
            testList = (List<Test>)Session["TestList"];
            order = (Order)Session["Order"];
            patientNameLabel.Text = patient.Name;
            DOBLabel.Text = patient.DOB.ToString("dd MMMM yyyy");
            patientMobileLabel.Text = patient.Mobile;
            billNoLabel.Text = "Bill No : " + order.BillNo;
            dateLabel.Text = "Date : " + DateTime.Now.ToString();
            testGridView.DataSource = testList;
            testGridView.DataBind();
        }
        float total = 0;
        protected void testGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblqy = (Label)e.Row.FindControl("lblqty");
                float qty = Single.Parse(lblqy.Text);
                total = total + qty;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalqty = (Label)e.Row.FindControl("lblTotalqty");
                lblTotalqty.Text = total.ToString();
            }
        }
    }
}