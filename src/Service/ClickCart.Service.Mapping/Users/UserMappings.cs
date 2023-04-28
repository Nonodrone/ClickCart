using ClickCart.Data.Models;
using ClickCart.Service.Models.Users;

namespace ClickCart.Service.Mapping.Users
{
    public static class UserMappings
    {
        public static ClickCartUser ToEntity(this ClickCartUserDto ClickCartUserDto)
        {
            return new ClickCartUser
            {
                Id = ClickCartUserDto.Id,
                UserName = ClickCartUserDto.UserName,
                Email = ClickCartUserDto.Email,
                Address = ClickCartUserDto.Address,
            };
        }

        public static ClickCartUserDto ToDto(this ClickCartUser ClickCartUser)
        {
            return new ClickCartUserDto
            {
                Id = ClickCartUser.Id,
                UserName = ClickCartUser.UserName,
                Email = ClickCartUser.Email,
                Address = ClickCartUser.Address
            };
        }
    }
}
