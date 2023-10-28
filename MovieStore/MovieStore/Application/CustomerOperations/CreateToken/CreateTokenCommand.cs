using Microsoft.IdentityModel.Tokens;
using MovieStore.DbOperations;
using MovieStore.TokenOperations;
using MovieStore.TokenOperations.Models;

namespace MovieStore.Application.CustomerOperations.CreateToken
{
    public class CreateTokenCommand
    {
        private readonly IMovieContext _context;
        private readonly IConfiguration _configuration;
        public CreateTokenModel Model {  get; set; } 

        public CreateTokenCommand(IMovieContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (customer != null)
            {
                TokensHandler tokenHandler = new TokensHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı Adı - Şifre Yanlış!");
            }
        }

        public class CreateTokenModel
        {
            public string? Email { get; set; }
            public string? Password { get; set; }
        }
    }
}
