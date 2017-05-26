namespace IssueTracker.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    using BindingModels;
    using Models;
    using Models.Enums;
    using Utillities;
    using ViewModels;

    public class UsersService : Service
    {
        public List<ErrorViewModel> ValidateRegisterUserBindingModel(RegisterUserBindingModel rubm)
        {
            List<ErrorViewModel> errors = new List<ErrorViewModel>();
            if (rubm.Username.Length < 5 || rubm.Username.Length > 30)
            {
                errors.Add(new ErrorViewModel(Constants.UsernameError));
            }

            if (rubm.FullName.Length < 5)
            {
                errors.Add(new ErrorViewModel(Constants.FullNameError));
            }

            bool hasUpperCase = Regex.IsMatch(rubm.Password, "[A-Z]");
            bool hasDigit = Regex.IsMatch(rubm.Password, "[0-9]");
            bool hasSymbol = Regex.IsMatch(rubm.Password, "[!@#$%^&*,.]");


            if (!hasUpperCase || 
                !hasDigit ||
                !hasSymbol ||
                rubm.Password.Length < 8)
            {
                errors.Add(new ErrorViewModel(Constants.PasswordError));
            }

            if (rubm.Password != rubm.ConfirmPassword)
            {
                errors.Add(new ErrorViewModel(Constants.MatchingPasswordsError));
            }

            return errors;
        }

        public void RegisterUser(RegisterUserBindingModel rubm)
        {
            bool anyUsers = this.UserRepository.All().Any();
            User userEntity = new User()
            {
                Username = rubm.Username,
                FullName = rubm.FullName,
                Password = rubm.Password,
                Role = anyUsers ? Role.Regular : Role.Administrator
            };

            this.UserRepository.Insert(userEntity);
            this.SaveChanges();
        }

        public bool LoginUser(LoginUserBindingModel lubm, string sessionId)
        {
            User existingUser = this.UserRepository
                .Find(u => u.Username == lubm.Username && u.Password == lubm.Password);
            if (existingUser != null)
            {
                Login loginEntity = new Login()
                {
                    SessionId = sessionId,
                    IsActive = true,
                    User = existingUser
                };

                this.LoginRepository.Insert(loginEntity);
                this.SaveChanges();
                return true;
            }

            return false;
        }

        public void LogoutUser(string sessionId)
        {
            Login loginEntity = this.LoginRepository
               .Find(l => l.SessionId == sessionId);

            loginEntity.IsActive = false;
            this.SaveChanges();
        }
    }
}
