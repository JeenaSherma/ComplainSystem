using AutoMapper;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;
using ComplaintSystem.Repository.Interfaces;
using ComplaintSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace ComplaintSystem.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public TokenService(IUnitOfWork uof, IMapper mapper)
        {
            this._uof = uof;
            this._mapper = mapper;
        }
        public async Task<List<TokenDto>> GetAllTokens()
        {
            try
            {
                var token = await _uof.Repository<Token>().GetAll();
                var tokenDto = _mapper.Map<List<TokenDto>>(token);
                return tokenDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting Tokens", ex);
            }
        }

        public async Task<TokenDto> GetTokenById(int TokenId)
        {
            try
            {
                var token = await _uof.Repository<Token>().GetById(TokenId);
                var tokenDto = _mapper.Map<TokenDto>(token);
                return tokenDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting token", ex);
            }
        }

        //public async Task<TokenDto> SaveToken(TokenDto tokenDto)
        //{
        //    try
        //    {
        //        var token = _mapper.Map<Token>(tokenDto);
        //        await _uof.Repository<Token>().Add(token);
        //        await _uof.SaveChangesAsync();
        //        return _mapper.Map<TokenDto>(token);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error while saving token", ex);
        //    }
        //}
        public async Task<string> GenerateAndSaveTokenForComplaint(int complaintId)
        {
            try
            {
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    byte[] randomBytes = new byte[4];
                    rng.GetBytes(randomBytes);

                    int extractedValue = BitConverter.ToInt32(randomBytes, 0);
                    int tokenValue = Math.Abs(extractedValue) % 100000; // Limit to 5 digits

                    var token = new Token
                    {
                        TokenValue = tokenValue.ToString("D5"),
                        ComplainId = complaintId
                    };
                    await _uof.Repository<Token>().Add(token);
                    await _uof.SaveChangesAsync();

                    return token.TokenValue;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while saving token", ex);
            }
        }


        //}public async Task<string> GenerateAndSaveTokenForComplaint(int complaintId)
        //{
        //    try
        //    {
        //        Guid newGuid = Guid.NewGuid();
        //        var token = new Token
        //        {
        //            TokenValue = newGuid.ToString(),
        //            ComplainId = complaintId
        //        };
        //        await _uof.Repository<Token>().Add(token);
        //        await _uof.SaveChangesAsync();
        //        var tokenstring = token.TokenValue;
        //        return tokenstring;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error while saving token", ex);
        //    }
        //}

        //[HttpPost]
        //public async Task<TokenDto> SaveToken(int complaintId)
        //{
        //    try
        //    {               
        //        Guid newGuid = Guid.NewGuid();                
        //        var token = new Token
        //        {
        //            TokenValue = newGuid.ToString(),
        //            ComplainId = complaintId
        //        };              
        //        await _uof.Repository<Token>().Add(token);
        //        await _uof.SaveChangesAsync();

        //        var tokenDto = _mapper.Map<TokenDto>(token);
        //        return tokenDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error while saving token", ex);
        //    }

        //}

        //public async Task<TokenDto> UpdateToken(int TokenId, TokenDto tokenDto)
        //{
        //    try
        //    {
        //        var token = await _uof.Repository<Token>().GetById(TokenId) ?? throw new Exception("Token not found");
        //        _mapper.Map(tokenDto, token);
        //        await _uof.SaveChangesAsync();
        //        return _mapper.Map<TokenDto>(token);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An error occurred while updating the token.", ex);
        //    }

        //}
        public async Task<int> DeleteToken(int TokenId)
        {
            try
            {
                var token = await _uof.Repository<Token>().GetById(TokenId) ?? throw new Exception("Token not found");
                _uof.Repository<Token>().Delete(token);
                return await _uof.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while deleting department", ex);
            }
        }

    }
}
