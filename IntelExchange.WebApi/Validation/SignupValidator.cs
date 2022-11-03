using IntelExchange.WebApi.Models;
using IntelExchange.DataModels;
using IntelExchange.DataModels.Enums;
using IntelExchange.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.RegularExpressions;

namespace IntelExchange.WebApi.Validation
{
    public class SignupValidator : BasicValidator<UserSignupModel>, IAsyncValidator<UserSignupModel>
    {
        private readonly IUserService _userService;
        private User? user;
        public SignupValidator(IActionContextAccessor actionContextAccessor, IUserService userService): base(actionContextAccessor)
        {
            _userService = userService;
        }
        public async Task ValidateAsync(UserSignupModel model)
        {
            var loginValidationTask = ValidateLoginPasswordPairAsync(model.Login, model.Password);
            var emailValidationTask = ValidateEmailAsyns(model.Profile.Email);
            ValidateUserProfile(model.Profile, model.UserType);
            await loginValidationTask;
            await emailValidationTask;
        }

        // validate both login in password to reduce number of database queries
        // if login is not valid, then we don't even start to validate if password is correct for user
        private async Task ValidateLoginPasswordPairAsync(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                _modelState.AddModelError("login", "validation.login_cannot_be_empty");
            }
            else
            {
                user = await _userService.GetUserByNameAsync(login);

                if (user == null)
                {
                    _modelState.AddModelError("login", "validation.no_such_user");
                }
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                _modelState.AddModelError("password", "validation.password_cannot_be_empty");
            }
            else
            {
                if (user != null)
                {
                    //todo: add password encryption/check service
                    if (password != user.Password)
                    {
                        _modelState.AddModelError("password", "validation.password_incorrect");
                    }
                }
            }
        }

        private async Task ValidateEmailAsyns(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                _modelState.AddModelError("email", "validation.email_cannot_be_empty");
            }
            else
            {
                var regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
                var isValid = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
                if(!isValid)
                {
                    _modelState.AddModelError("email", "validation.email_is_not_valid");
                    return;
                }
               
            }

            var users = await _userService.GetAllUsersAsync();
            var userWithEmail = users.SingleOrDefault(user => user.Profile.Email == email);
            if (userWithEmail != null)
            {
                _modelState.AddModelError("email", "validation.email_already_used");
            }


        }

        private void ValidateUserProfile(UserProfile profile, UserType userType)
        {
            if(string.IsNullOrWhiteSpace(profile.PhoneNumber))
            {
                _modelState.AddModelError("phoneNumber", "validation.phone_number_cannot_be_empty");
            }
            
            else
            {
                var regex = @"^(\+[0-9]{9})$";
                var isValidPhoneNumber = Regex.IsMatch(profile.PhoneNumber, regex, RegexOptions.IgnoreCase);
                if(!isValidPhoneNumber)
                {
                    _modelState.AddModelError("phoneNumber", "validation.phone_number_is_not_valid");
                }                
            }

            if(userType == UserType.Individual)
            {
                ValidateIndividualProfile(profile as IndividualProfile);
            }
            else
            {
                ValidateCompanyProfile(profile as CompanyProfile);
            }
        }

        private void ValidateIndividualProfile(IndividualProfile profile)
        {
            if(string.IsNullOrWhiteSpace(profile.Address))
            {
                _modelState.AddModelError("address", "validation.address_cannot_be_empty");
            }

            if (string.IsNullOrWhiteSpace(profile.FirstName))
            {
                _modelState.AddModelError("firstName", "validation.firstName_cannot_be_empty");
            }

            if (string.IsNullOrWhiteSpace(profile.LastName))
            {
                _modelState.AddModelError("lastName", "validation.lastName_cannot_be_empty");
            }

        }

        private void ValidateCompanyProfile(CompanyProfile profile)
        {
            if(string.IsNullOrWhiteSpace(profile.CompanyForm))
            {
               _modelState.AddModelError("companyForm", "validation.company_form_cannot_be_empty");
            }

            if (string.IsNullOrWhiteSpace(profile.CompanyName))
            {
                _modelState.AddModelError("companyName", "validation.company_name_cannot_be_empty");
            }

            if (string.IsNullOrWhiteSpace(profile.ITIN))
            {
                _modelState.AddModelError("itin", "validation.itin_cannot_be_empty");
            }
        }
    }
}
