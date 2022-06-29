using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IExportPdfService
    {
        Task<string> GeneratePdf(int ticketId);
    }
}
