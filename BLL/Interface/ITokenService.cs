using DAL.Models;

namespace BLL.Interface
{
    public interface ITokenService
    {
       string CreateToken(ApplicationUser user, IList<string> roles);
    }
}
