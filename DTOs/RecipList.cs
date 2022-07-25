namespace sponapp.DTOs
{
    public class RecipList
    {
        public RecipList()
        {
        }

        public RecipList(IEnumerable<Recipe> recipes)
        {
            recipes = recipes;
        }

        public IEnumerable<Recipe> recipes { get; set; } = new List<Recipe>();  
    }
}
