using ComplaintSystem.Dtos;

namespace ComplaintSystem.Services.Interfaces
{
    public interface ITokenService
    {
        Task<List<TokenDto>> GetAllTokens();
        Task<TokenDto> GetTokenById(int TokenId);
      //Task<TokenDto> SaveToken(int complainId);
      //  Task<TokenDto> UpdateToken(int TokenId, TokenDto tokenDto);
        Task<int> DeleteToken(int TokenId);
        Task<string> GenerateAndSaveTokenForComplaint(int complaintId);

    }
}
