using SmartIntranet.Business.Interfaces.Intranet.Archives;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.Intranet.Archives;
using SmartIntranet.Entities.Concrete.Intranet.Archives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete.Intranet.Archives
{
    public class ArchiveManager : GenericManager<Archive>, IArchiveService
    {
        private readonly IGenericDal<Archive> _genericDal;
        private readonly IArchiveDal _archiveDal;

        public ArchiveManager(IGenericDal<Archive> genericDal, IArchiveDal archiveDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _archiveDal = archiveDal;
        }


        public Task<List<Archive>> GetAllIncAsync(int companyId)
        {
            return _archiveDal.GetAllIncAsync(companyId);
        }
    }
}
