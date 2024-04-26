using CsvHelper.Configuration;
using TestAuto.Application.CQRS.Drinks.Commands.CreateDrink;

namespace TestAuto.Application.Services.CsvParser.Emplementation
{
    public class CreateDrinkCommandMap : ClassMap<CreateDrinkComamnd>
    {
        public CreateDrinkCommandMap()
        {
            Map(i => i.Count).Name("количество");
            Map(i => i.Price).Name("цена");
            Map(i => i.Name).Name("название");
            Map(i => i.Count).Name("количество");
        }
    }
}
