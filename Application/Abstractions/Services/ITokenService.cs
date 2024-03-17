using Esame_Enterprise.Application.Models.Requests;

namespace Esame_Enterprise.Application.Abstractions.Services
{
    public interface ITokenService
    {

        string CreateToken(CreateTokenRequest request);

    }
}
