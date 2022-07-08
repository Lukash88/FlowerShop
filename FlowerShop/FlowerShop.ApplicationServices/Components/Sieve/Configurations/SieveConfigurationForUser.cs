using FlowerShop.DataAccess.Entities;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForUser : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<User>(u => u.Role)
               .CanSort()
               .CanFilter(); ;

            mapper.Property<User>(u => u.UserName)
                .CanSort()
                .CanFilter();

            mapper.Property<User>(u => u.SecondName)
                .CanSort()
                .CanFilter();
        }
    }
}
