using System.ComponentModel.DataAnnotations;

namespace FlowerShop.DataAccess.Core.Entities
{
    public  abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}