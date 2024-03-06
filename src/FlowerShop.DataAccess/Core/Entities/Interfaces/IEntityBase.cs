using System.ComponentModel.DataAnnotations;

namespace FlowerShop.DataAccess.Core.Entities.Interfaces
{
    public interface IEntityBase
    {
        [Key]
        public int Id { get; }
    }
}