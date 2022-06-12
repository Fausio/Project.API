using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Project.Web.API.Token
{
    public class JWTSecurityKey
    {
        public static SymmetricSecurityKey Create(string secrest)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secrest));
        }
    }
}
