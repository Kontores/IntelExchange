using IntelExchange.DataModels;
using IntelExchange.DataModels.Enums;

namespace IntelExchange.Database.Mocks
{
    public class UserDataMock
    {
        public List<User> Users {get; set;}
        public List<UserProfile> UserProfiles {get; set;}

        public UserDataMock()
        {
            var userIds = new List<Guid>
            {
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
            };


            Users = new List<User>()
            {
                new User(userIds.First(), "Kirill", "passOne1", UserType.Individual)
                {
                    Profile = new IndividualProfile(userIds.First(), "kirill@somemail.com", "79012324556", "Kirill", "Kontorez", "no address"),
                    Roles = new List<UserRole>() { UserRole.Admin, UserRole.TraderCreator, UserRole.Observer}
                },
                new User(userIds.Skip(1).First(), "John", "passTwo", UserType.Individual)
                {
                    Profile = new IndividualProfile(userIds.Skip(1).First(), "john@dow.com", "21343224",  "John", "Dow", "some street"),
                },
                new User(userIds.Last(), "CapitalFund", "passThree", UserType.Company)
                {
                    Profile = new CompanyProfile(userIds.Last(), "capital.fund@mail.com", "+12321", "Capital Fund", "Ltd", "Main street 25", "10320201"),                }
            };

            UserProfiles = Users.Select(u => u.Profile).ToList();
        }
    }
}
