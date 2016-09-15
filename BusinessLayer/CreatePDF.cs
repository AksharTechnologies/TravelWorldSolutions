using ModelsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;
using iTextSharp.text.html;

namespace BusinessLayer
{
    public static class CreatePDF
    {
        public static string createAndSavePDF(ProposalModel prpsl)
        {

            string returnValue = string.Empty;
            string pathWherePDFIsSaved =System.Web.HttpContext.Current.Server.MapPath("~/Attachments/Proposal"+DateTime.Now.ToString().Replace(":","")+".pdf") ;
            FileStream fs = new FileStream(pathWherePDFIsSaved, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            var font1 = FontFactory.GetFont(@"C:\Users\lenovo\Downloads\fonts\Ubuntu-Regular.ttf", 9, Color.DARK_GRAY);
            var font2 = FontFactory.GetFont(@"C:\Users\lenovo\Downloads\fonts\Ubuntu-Regular.ttf", 9);
            var font3 = FontFactory.GetFont(@"C:\Users\lenovo\Downloads\fonts\Sacramento-Regular.ttf", 14, Font.BOLD, Color.BLUE);
            var fontHotelDetailHeader = FontFactory.GetFont(@"C:\Users\lenovo\Downloads\fonts\Ubuntu-Regular.ttf", 9,Font.BOLD);

            var phraseHeader = new Phrase();
            phraseHeader.Add(new Chunk("Travel World Solutions : ", font3));
            doc.Add(new Paragraph(phraseHeader));

            //
            PdfPTable tableClientDetails = new PdfPTable(1);
            tableClientDetails.SpacingBefore = 4f;
            tableClientDetails.WidthPercentage = 100f;
            tableClientDetails.HorizontalAlignment = Element.ALIGN_LEFT;
            PdfPCell cellClientDetails = new PdfPCell(new Phrase("Client Details :", fontHotelDetailHeader));
            cellClientDetails.PaddingTop = 3f;
            cellClientDetails.Border = 0;
            cellClientDetails.BorderColorBottom = Color.BLACK;
            cellClientDetails.BorderWidthBottom = 1.5f;
            cellClientDetails.PaddingBottom = 3.5f;
            tableClientDetails.AddCell(cellClientDetails);

            doc.Add(tableClientDetails);
            //
            var phraseClientName = new Phrase();
            phraseClientName.Add(new Chunk("[1] Client Name : ", font2));
            phraseClientName.Add(new Chunk(prpsl.ClientName, font1));
            doc.Add(new Paragraph(phraseClientName));

            var phraseNumberOfPersons = new Phrase();
            phraseNumberOfPersons.Add(new Chunk("[2] Number Of Persons: ", font2));
            phraseNumberOfPersons.Add(new Chunk(prpsl.NumberOfPersons.ToString(), font1));
            doc.Add(new Paragraph(phraseNumberOfPersons));

            var phraseNumberOfRooms = new Phrase();
            phraseNumberOfRooms.Add(new Chunk("[3] Number Of Rooms : ", font2));
            phraseNumberOfRooms.Add(new Chunk(prpsl.NumberOfRooms.ToString(), font1));
            doc.Add(new Paragraph(phraseNumberOfRooms));

            var phraseFromDate = new Phrase();
            phraseFromDate.Add(new Chunk("[4] From Date : ", font2));
            phraseFromDate.Add(new Chunk( string.Format("{0:D}",prpsl.FromDate), font1));
            doc.Add(new Paragraph(phraseFromDate));

            var phraseToDate = new Phrase();
            phraseToDate.Add(new Chunk("[5] To Date : ", font2));
            phraseToDate.Add(new Chunk(string.Format("{0:D}",prpsl.ToDate), font1));
            doc.Add(new Paragraph(phraseToDate));

            string sqlQuery = "select * from hotels where id in ("+ string.Join(",",prpsl.listOfHotelIds)+")";
            DataSet dsHotels= DatabaseLayer.DatabaseBroker.GetDataSet(sqlQuery);
            int cnt = 0;
            foreach (DataRow row in dsHotels.Tables[0].Rows)
            {
                var phraseHotelDetails = new Phrase();
                PdfPTable tableHotelDetails = new PdfPTable(3);
                tableHotelDetails.WidthPercentage = 100f;
                
                tableHotelDetails.SpacingBefore = cnt==0?15:5;
                cnt++;
                tableHotelDetails.SpacingAfter = 5;

                tableHotelDetails.HorizontalAlignment = Element.ALIGN_LEFT;
                PdfPCell cellHeader = new PdfPCell(new Phrase(" Hotel-Name : "+row["Name"].ToString(), fontHotelDetailHeader));
                cellHeader.Colspan = 3;
                cellHeader.Border = 0;
                cellHeader.BorderColorBottom = Color.BLACK;
                cellHeader.BorderWidthBottom = 1.5f;
                cellHeader.PaddingBottom = 3.5f;
                tableHotelDetails.AddCell(cellHeader);

                PdfPCell cellAddress1 = new PdfPCell(new Phrase(" Address-1 :" + row["AddressLine1"].ToString(), font2));
                cellAddress1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellAddress1.Border = 0;
                cellAddress1.BorderColorRight = WebColors.GetRGBColor("#B0171F"); 
                cellAddress1.BorderWidthRight = 1.5f;
                cellAddress1.HorizontalAlignment = Element.ALIGN_MIDDLE;
                cellAddress1.BorderColorLeft = WebColors.GetRGBColor("#B0171F");
                cellAddress1.BorderWidthLeft = 1.5f;
                tableHotelDetails.AddCell(cellAddress1);

                PdfPCell cellEmailaddress1 = new PdfPCell(new Phrase(" Email-Address-1 :" + row["EmailAddress1"].ToString(), font2));
                cellEmailaddress1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellEmailaddress1.Border = 0;
                cellEmailaddress1.BorderColorRight = WebColors.GetRGBColor("#B0171F");
                cellEmailaddress1.BorderWidthRight = 1.5f;
                tableHotelDetails.AddCell(cellEmailaddress1);


                PdfPCell phoneNumber1 = new PdfPCell(new Phrase(" Phone-Number-1 :" + row["PhoneNumber1"].ToString(), font2));
                phoneNumber1.VerticalAlignment = Element.ALIGN_MIDDLE;
                phoneNumber1.Border = 0;
                phoneNumber1.BorderColorRight = WebColors.GetRGBColor("#B0171F");
                phoneNumber1.BorderWidthRight = 1.5f;
                phoneNumber1.PaddingTop = 1f;
                tableHotelDetails.AddCell(phoneNumber1);


                PdfPCell cellAddress2 = new PdfPCell(new Phrase(" Address-2 :" + row["AddressLine2"].ToString(), font2));
                cellAddress2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellAddress2.Border = 0;
                cellAddress2.BorderColorRight = WebColors.GetRGBColor("#B0171F");
                cellAddress2.BorderWidthRight = 1.5f;
                cellAddress2.BorderWidthLeft = 1.5f;
                cellAddress2.BorderColorLeft = WebColors.GetRGBColor("#B0171F");
                tableHotelDetails.AddCell(cellAddress2);

              
                PdfPCell cellEmailaddress2 = new PdfPCell(new Phrase(" Email-Address-2 :" + row["EmailAddress2"].ToString(), font2));
                cellEmailaddress2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellEmailaddress2.Border = 0;
                cellEmailaddress2.BorderColorRight = WebColors.GetRGBColor("#B0171F");
                cellEmailaddress2.BorderWidthRight = 1.5f;
                cellEmailaddress2.PaddingTop = 1f;
                tableHotelDetails.AddCell(cellEmailaddress2);


                PdfPCell phoneNumber2 = new PdfPCell(new Phrase(" Phone-Number-2 :"+row["PhoneNumber2"].ToString(), font2));
                phoneNumber2.VerticalAlignment = Element.ALIGN_MIDDLE;
                phoneNumber2.Border = 0;
                phoneNumber2.BorderColorRight = WebColors.GetRGBColor("#B0171F");
                phoneNumber2.BorderWidthRight = 1.5f;
                phoneNumber2.PaddingTop = 1f;
                tableHotelDetails.AddCell(phoneNumber2);

                phraseHotelDetails.Add(tableHotelDetails);
                doc.Add(new Paragraph(phraseHotelDetails));
            } 
            doc.Close();
            returnValue = pathWherePDFIsSaved.Trim();           
            return returnValue;
        }
    }
}
