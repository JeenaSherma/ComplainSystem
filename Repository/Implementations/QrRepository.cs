using ComplaintSystem.DbContext;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ComplaintSystem.Repository.Implementations
{
    public class QrRepository : IQrRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public QrRepository(ApplicationDbContext applicationDbContext) 
        {
            this._applicationDbContext = applicationDbContext;
        }

     public async  Task<QRinfo> GetQRinfoByMunicipalityId(int municipalityId)
        {
          return  await _applicationDbContext.qRinfos.FirstOrDefaultAsync(qr=>qr.MunicipalityId == municipalityId);

        }
    }
}
