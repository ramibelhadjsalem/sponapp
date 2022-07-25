
using sponapp.Data.FoodRepository;
using sponapp.DTOs;

namespace sponapp.Data
{
    public interface IUnitOfWork
    {
       
        IfoodRepo foods { get; }
    }
}
