using System;
using System.Collections.Generic;
using System.Text;


namespace SmartIntranet.DTO.DTOs.OrderDto
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Currency { get; set; }
        public string Quantity { get; set; }
        public string WithoutVat { get; set; }
        public string TotalWithoutTax { get; set; }
        public string TaxType { get; set; }
        public string Total { get; set; }
        public string Seller { get; set; }
        public string Description { get; set; }
        public string GrandTotal { get; set; }
        public int TicketId { get; set; }

    }
}
