using Mappers.Models;
using Mappers.CustomMapper.MapperService;
using Mappers.CustomMapper.Reflection;
using Mappers.CustomMapper.EFSelect;


var user = new User
{
    Region = "Serbia",
    Address = "Some address in Serbia",
    PostalCode = "18000",
    Password = "password",
    City = "Nis",
    Email = " stefan@stefandjokic.tech",
    FirstName = "Stefan",
    LastName = "Djokic",
    Id = 1
};

List<User> users = new List<User> { user };



//#1 Approach - Reflection

var mapper = new Mapper<User, UserModel>();

List<UserModel> userModels = mapper.Map(users);




//2# Approach - Custom Mapper Service

//Register to DI
var _mapperService = new UserMapperService();

UserModel model = _mapperService.MapToUserModel(user);




//3# Approach - EntityFramework Select method

var _userRepository = new UserRepository();

//Go to implementation to see details
List<UserModel> repoUserModels = _userRepository.GetUsers();
