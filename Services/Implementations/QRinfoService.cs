using AutoMapper;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;
using QRCoder;

namespace ComplaintSystem.Services.Implementations
{
    public class QRinfoService : IQRInfoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        private readonly IQrRepository _qrRepository;

        public QRinfoService(IUnitOfWork uow, IMapper mapper, IQrRepository qrRepository)
        {
            this._uow = uow;
            this._mapper = mapper;
            this._qrRepository = qrRepository;
        }
        public async Task<List<QRinfoDto>> GetAllQRInfo()
        {
            try
            {

                var qrinfos = await _uow.Repository<QRinfo>().GetAll();
                var qrinfoDto = _mapper.Map<List<QRinfoDto>>(qrinfos);
                return qrinfoDto;

            }
            catch (Exception ex)
            {
                throw new Exception("Error trying to get Qr", ex);
            }
        }

        public async Task<QRinfoDto> GetQRInfobyId(int QRId)
        {
            try
            {
                var qrInfo = await _uow.Repository<QRinfo>().GetById(QRId);
                var qrinfoDto = _mapper.Map<QRinfoDto>(qrInfo);
                return qrinfoDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error trying to get QRInfo", ex);
            }
        }

        public async Task<QRinfoDto> SaveQRInfo(QRinfoDto QRInfoDto)
        {
            try
            {
                var qRinfo = _mapper.Map<QRinfo>(QRInfoDto);
                await _uow.Repository<QRinfo>().Add(qRinfo);
                await _uow.SaveChangesAsync();
                var responseQrinfo = _uow.Repository<QRinfo>().GetAllIncluding(x => x.Municipality).Result.First(x => x.Id == qRinfo.Id);
                return _mapper.Map<QRinfoDto>(responseQrinfo);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occured while saving qrinfo", ex);
            }
        }

        public async Task<QRinfoDto> UpdateQRInfo(int QRId, QRinfoDto QRInfoDto)
        {
            try
            {
                var qr = await _uow.Repository<QRinfo>().GetById(QRId) ?? throw new Exception("No Qr found");
                _mapper.Map(QRInfoDto, qr);
                await _uow.SaveChangesAsync();
                return _mapper.Map<QRinfoDto>(qr);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occred while updating Qr Information", ex);
            }
        }
        public async Task<int> DeleteQRInfo(int QRId)
        {
            try
            {
                var qr = await _uow.Repository<QRinfo>().GetById(QRId) ?? throw new Exception("No QR found");
                _uow.Repository<QRinfo>().Delete(qr);
                return await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while deleting QRInfo", ex);
            }
        }

        public async Task<QRinfoDto> GetQrinfoByMunicipalityId(int MunicipalityId)
        {
            try
            {
                var qrInfo = await _qrRepository.GetQRinfoByMunicipalityId(MunicipalityId);
                var qrinfoDto = _mapper.Map<QRinfoDto>(qrInfo);
                return qrinfoDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error trying to get QRInfo", ex);
            }
        }
    }
}
