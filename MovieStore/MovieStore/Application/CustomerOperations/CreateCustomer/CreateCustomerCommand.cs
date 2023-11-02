using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.CustomerOperations.CreateCustomer
{
    public class CreateCustomerCommand
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerModel Model { get; set; }

        public CreateCustomerCommand(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _context.Customers
                .SingleOrDefault(x => x.Email == Model.Email);
            if (customer != null) 
            {
                throw new InvalidOperationException("Bu Email Hesabı Zaten Kayıtlı");
            }
            customer = _mapper.Map<Customer>(Model);
            
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public class CreateCustomerModel
        {
            public string? CustomerName { get; set; }
            public string? CustomerSurname { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
        }
    }
}
