using Microsoft.IdentityModel.Tokens;
using MovieStore.Entities;
using MovieStore.TokenOperations.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MovieStore.TokenOperations
{
    public class TokensHandler
    {
        public IConfiguration _configuration { get; set; }
        public TokensHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(Customer customer)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManagers.Appsetting["Jwt:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration = DateTime.Now.AddMinutes(30);

            JwtSecurityToken securityToken = new JwtSecurityToken
                (
                issuer: ConfigurationManagers.Appsetting["Jwt:Issuer"],
                audience: ConfigurationManagers.Appsetting["Jwt:Audience"],
                expires: tokenModel.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: credentials
                );


            //Token Üretiliyor
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
