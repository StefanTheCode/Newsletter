using Mappers.Models;

namespace Mappers.CustomMapper.EFSelect
{
    public class UserRepository
    {
        List<User> users = new List<User>
        {
            new User {
                        Region = "Serbia",
                        Address = "Some address in Serbia",
                        PostalCode = "18000",
                        Password = "password",
                        City = "Nis",
                        Email = " stefan@stefandjokic.tech",
                        FirstName = "Stefan",
                        LastName = "Djokic",
                        Id = 1
                    }
        };

        public List<UserModel> GetUsers()
        {
            return users.Select(x => new UserModel
            {
                Region = x.Region,
                Address = x.Address,
                PostalCode = x.PostalCode,
                Password = x.Password,
                City = x.City,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id
            }).ToList();
        }
    }
}