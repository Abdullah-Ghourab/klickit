using Microsoft.AspNetCore.Identity;

namespace klickit.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser User, string role);
    }
}
