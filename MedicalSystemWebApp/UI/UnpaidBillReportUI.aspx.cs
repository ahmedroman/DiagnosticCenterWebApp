using MedicalSystemWebApp.BLL;
using MedicalSystemWebApp.Models.View;
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
    public partial class UnpaidBillReportUI : System.Web.UI.Page
    {
        ViewManager viewManager = new ViewManager();
        List<ViewOrderWithPatient> patientwithUnpaidBill = new List<ViewOrderWithPatient>();

        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            pdfButton.Visible = false;
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(fromDateTextBox.Text);
                DateTime toDate = Convert.ToDateTime(toDateTextBox.Text);
                viewManager.ValidationFunction(fromDate, toDate);

                patientwithUnpaidBill = viewManager.GetUnpaidBillWithPatient(fromDate, toDate);
                LoadPatientGridView();
            }
            catch (FormatException formatException)
            {
                messageLabel.Text = "Invalid date";
            }
            catch (Exception exception)
            {
                messageLabel.Text = exception.Message;
            }
        }
        private void LoadPatientGridView()
        {
            if (patientwithUnpaidBill.Count > 0)
            {
                showUnpaidGridview.DataSource = patientwithUnpaidBill;
                showUnpaidGridview.DataBind();
                pdfButton.Visible = true;
            }
            else 
            {
                messageLabel.Text = "No data found";
            }
            
        }
        float toatlAmount;
        protected void showUnpaidGridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label feeLabel = (Label)e.Row.FindControl("feeLabel");
                toatlAmount += Convert.ToSingle(feeLabel.Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label totalAmountLabel = (Label)e.Row.FindControl("totalAmountLabel");
                totalAmountLabel.Text = toatlAmount.ToString();
            }
        }
        

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            header.Visible = false;
            navigation.Visible = false;
            footer.Visible = false;
            dateTable.Visible = false;
            pdfButton.Visible = false;
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
    }
}