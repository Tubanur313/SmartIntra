using SmartIntranet.DataAccess.Interfaces.Intranet.FAQ;
using SmartIntranet.Entities.Concrete.Intranet.FAQ;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Intranet.FAQ
{
    public class EfFaqRepository : EfGenericRepository<Faq>, IFaqDal
    {
    }
}
