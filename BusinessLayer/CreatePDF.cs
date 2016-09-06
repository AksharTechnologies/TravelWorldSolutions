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

namespace BusinessLayer
{
    public static class CreatePDF
    {
        public static bool createAndSavePDF(ProposalModel prpsl)
        {
            

            string pathWherePDFIsSaved =System.Web.HttpContext.Current.Server.MapPath("~/Attachments/Proposal"+DateTime.Now.ToString().Replace(":","")+".pdf") ;
            FileStream fs = new FileStream(pathWherePDFIsSaved, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            var font1 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, Color.DARK_GRAY);
            var font2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
            var font3 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, Color.BLUE);

            var phraseHeader = new Phrase();
            phraseHeader.Add(new Chunk("Travel World Solutions : ", font3));
            doc.Add(new Paragraph(phraseHeader));

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

            string sqlQuery = "select * from cdgmaster.hotels where id in ("+prpsl.listOfHotelIds+")";
            DataSet dsHotels= DatabaseLayer.DatabaseBroker.GetDataSet(sqlQuery);

            foreach (DataRow row in dsHotels.Tables[0].Rows)
            {
                var phraseHotelDetails = new Phrase();

            } 
            doc.Close();
            bool returnValue = false;
            return returnValue;
        }
    }
}
