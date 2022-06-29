using iTextSharp.text;
using iTextSharp.text.pdf;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Business.Interfaces.IntraTicket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class ExportPdfManager : IExportPdfService
    {
        private readonly ITicketOrderService _ticketOrderService;
        private readonly ITicketService _ticketService;
        public ExportPdfManager(ITicketOrderService ticketOrderService, ITicketService ticketService)
        {
            _ticketOrderService = ticketOrderService;
            _ticketService = ticketService;
        }
        public async Task<string> GeneratePdf(int ticketId)
        {
            var ticketOrderList = await _ticketOrderService.GetAllIncludeAsync(ticketId);

            int pdfRowIndex = 1;
            string filename = "OrderDetails-" + DateTime.UtcNow.ToString("dd-MM-yyyy hh_mm_s_tt");
            string filepath = Path.Combine(Directory.GetCurrentDirectory()) + "/wwwroot/order/" + filename + ".pdf";

            string orderPath = "/order/" + filename + ".pdf";

            var update = await _ticketService.FindByIdAsync(ticketId);
            update.OrderPath = orderPath;
            await _ticketService.UpdateAsync(update);

            Document document = new Document(PageSize.A4, 5f, 5f, 10f, 10f);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            Font font1 = FontFactory.GetFont(FontFactory.COURIER_BOLD, 10);
            Font font2 = FontFactory.GetFont(FontFactory.COURIER, 8);

            float[] columnDefinitionSize = { 1F, 1F, 1F, 1F, 1F, 1F, 1F, 1F, 1F };
            PdfPTable table;
            PdfPCell cell;

            table = new PdfPTable(columnDefinitionSize)
            {
                WidthPercentage = 100
            };

            cell = new PdfPCell
            {
                BackgroundColor = new BaseColor(0xC0, 0xC0, 0xC0)
            };

            //table.AddCell(new Phrase("Id", font1));
            table.AddCell(new Phrase("Mehsul", font1));
            table.AddCell(new Phrase("Ö/V", font1));
            table.AddCell(new Phrase("Say", font1));
            table.AddCell(new Phrase("Qiymet(EDV/Xaric)", font1));
            table.AddCell(new Phrase("Cemi(V/X)", font1));
            table.AddCell(new Phrase("Vergi Növü", font1));
            table.AddCell(new Phrase("Yekun Mebleg(V/D)", font1));
            table.AddCell(new Phrase("Satici", font1));
            table.AddCell(new Phrase("Qeyd", font1));
            table.HeaderRows = 1;

            foreach (var data in ticketOrderList)
            {
                //table.AddCell(new Phrase(data.Order.Id.ToString(), font2));
                table.AddCell(new Phrase(data.Order.Product != null ? data.Order.Product.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Currency != null ? data.Order.Currency.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Quantity != null ? data.Order.Quantity.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.WithoutVat != null ? data.Order.WithoutVat.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.TotalWithoutTax != null ? data.Order.TotalWithoutTax.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.TaxType != null ? data.Order.TaxType.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Total != null ? data.Order.Total.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Seller != null ? data.Order.Seller.ToString() : "", font2));
                table.AddCell(new Phrase(data.Order.Description != null ? data.Order.Description.ToString() : "", font2));

                pdfRowIndex++;
            }

            document.Add(table);
            document.Close();
            document.CloseDocument();
            document.Dispose();
            writer.Close();
            writer.Dispose();
            fs.Close();
            fs.Dispose();
            return orderPath;
        }
    }
}
