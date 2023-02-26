using Mappers.Models;

namespace Mappers.CustomMapper.MapperService;

public class UserMapperService
{
    public User MapToUser(UserModel userModel)
    {
        return new User
        {
            Id = userModel.Id,
            Address = userModel.Address,
            City = userModel.City,
            Email = userModel.Email,
            FirstName = userModel.FirstName,
            LastName = userModel.LastName,
            Password = userModel.Password,
            PostalCode = userModel.PostalCode,
            Region = userModel.Region
        };
    }

    public UserModel MapToUserModel(User user)
    {
        return new UserModel
        {
            Id = user.Id,
            Address = user.Address,
            City = user.City,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password = user.Password,
            PostalCode = user.PostalCode,
            Region = user.Region
        };
    }
}
