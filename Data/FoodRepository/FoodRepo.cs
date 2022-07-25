

using sponapp.Entities;

namespace sponapp.Data.FoodRepository
{
    public class FoodRepo : BaseRepository<FoodItem>, IfoodRepo
    {
        public FoodRepo(DataContext Context) : base(Context)
        {
        }

       
    }
}
