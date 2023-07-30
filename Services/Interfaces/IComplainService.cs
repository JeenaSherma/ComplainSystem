﻿using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IComplainService
    {
        Task<List<ComplainDto>> GetAllComplains();
        Task<ComplainDto> GetComplainById(int ComplainId);
        Task<ComplainDto> SaveComplain(ComplainDto complainDto);
        Task<int> DeleteComplain(int ComplainId);
    }
}
