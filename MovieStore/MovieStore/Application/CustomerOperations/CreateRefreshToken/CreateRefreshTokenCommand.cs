using MovieStore.DbOperations;
using MovieStore.TokenOperations;
using MovieStore.TokenOperations.Models;

namespace MovieStore.Application.CustomerOperations.CreateRefreshToken
{
    public class CreateRefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IMovieContext _context;
        private readonly IConfiguration _configuration;

        public CreateRefreshTokenCommand(IMovieContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (customer != null)
            {
                TokensHandler tokensHandler = new TokensHandler(_configuration);
                Token token = tokensHandler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid bir refresh token bulunamadı!");
            }
        }
    }
}
