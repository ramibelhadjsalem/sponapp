

using sponapp.Data.FoodRepository;
using sponapp.DTOs;

namespace sponapp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IfoodRepo _foodRepo ;
     
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IfoodRepo foods => _foodRepo ??= new FoodRepo(_context);

      
    }
}
