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
    public partial class TypewiseReportUI : System.Web.UI.Page
    {
        ViewManager viewManager = new ViewManager();
        List<ViewOrderWithDate> orderWithDateList;

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

                orderWithDateList = viewManager.GetOrderWithDate(fromDate, toDate, "TestTypeName");
                LoadTestGridView();
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
        private void LoadTestGridView()
        {
            List<ViewOrderWithDate> finalOrderWithDateList = GetModifiedGridView();
            if (finalOrderWithDateList.Count > 0)
            {
                showAllTestGridview.DataSource = finalOrderWithDateList;
                showAllTestGridview.DataBind();
                pdfButton.Visible = true;
            }
            else {
                messageLabel.Text = "No data found";
            }
        }
        private List<ViewOrderWithDate> GetModifiedGridView()
        {
            ViewOrderWithDate lastObj = new ViewOrderWithDate();
            lastObj.TestTypeName = "";
            orderWithDateList.Add(lastObj);

            List<ViewOrderWithDate> typeWithCountList = new List<ViewOrderWithDate>();
            for (int i = 0; i < orderWithDateList.Count - 1; i++)
            {
                int c = 1;
                float totalFee = orderWithDateList[i].Fee;
                for (int j = i + 1; j < orderWithDateList.Count; j++)
                {
                    if (orderWithDateList[i].TestTypeName != orderWithDateList[j].TestTypeName)
                    {
                        ViewOrderWithDate uniqueItem = new ViewOrderWithDate();
                        uniqueItem.Count = c;
                        uniqueItem.TotalFee = totalFee; 
                        uniqueItem.TestTypeName = orderWithDateList[i].TestTypeName;
                        //totalFee += orderWithDateList[i].Fee;
                        //uniqueItem.TotalFee =+ orderWithDateList[i].Fee;
                        //uniqueItem.TotalFee = totalFee;
                        typeWithCountList.Add(uniqueItem);
                        i = j - 1;
                        break;
                    }
                    else
                    {
                        c++;
                        totalFee += orderWithDateList[j].Fee;
                    }
                }
            }
            return typeWithCountList;
        }
        float totalAmount;
        protected void showAllTestGridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label fee = (Label)e.Row.FindControl("feeLabel");
                totalAmount += Convert.ToSingle(fee.Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label totalAmountLabel = (Label)e.Row.FindControl("totalAmountLabel");
                totalAmountLabel.Text = totalAmount.ToString();
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
            Response.AddHeader("content-disposition", "attachment;filename=typewiseReport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            //pdfDoc.Add(pdfTable);
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

    }
}
