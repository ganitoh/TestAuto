namespace TestAuto.Domain.Models
{
    public class Dispenser
    {
        public int Id { get; set; }
        public List<Coin> Coins { get; set; } = [];
        public IReadOnlyCollection<Drink> Drinks => drinks;
        private List<Drink> drinks = [];

        public void AddDrink(Drink drink) => drinks.Add(drink);
    }
}
