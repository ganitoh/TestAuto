using System.ComponentModel.DataAnnotations;

namespace TestAuto.WebAPI.Contracts
{
    public record class AddDrinkRequest(
        [Required]string name,
        [Required]int count ,
        [Required]decimal price,
        [Required]IFormFile file,
        int dispenserId = 1);
}
