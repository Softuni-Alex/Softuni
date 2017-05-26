using DataTransferObjects.BindingModels;
using DataTransferObjects.Enumerations;
using DbEntities.Models;
using RepositoryLayer.Interfaces;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Utility.Interfaces;

namespace Utility.Utilities
{
    public class AccoutManager : IAccountManager
    {
        private readonly IIssueTrackerData data;

        public AccoutManager(IIssueTrackerData data)
        {
            this.data = data;
        }

        //Login
        public void LogUser(LoginUserBingingModel loginModel, string sessionId)
        {
            var user = this.data.User.Query()
                .FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);

            Login login = new Login()
            {
                UserId = user.Id,
                IsActive = true,
                SessionId = sessionId
            };

            this.data.Logins.Add(login);
            this.data.SaveChanges();

            //            var user = this.data.User.Query()
            //                 .FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);
            //
            //            if (user != null)
            //            {
            //                var login = this.data.Logins.Query()
            //                    .FirstOrDefault(l => l.UserId == user.Id && l.SessionId == sessionId);
            //
            //                if (login != null)
            //                {
            //                    login.IsActive = true;
            //                }
            //                else
            //                {
            //                    login = new Login()
            //                    {
            //                        IsActive = true,
            //                        UserId = user.Id,
            //                        SessionId = sessionId
            //                    };
            //                }
            //
            //                //add addorupdate in repository if needed
            //                this.data.Logins.Add(login);
            //                this.data.SaveChanges();
            //            return true;
            //            }
            //            return false;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            var desiredUser = this.data.Logins.Query().FirstOrDefault(l => l.SessionId == sessionId && l.IsActive);

            if (desiredUser != null)
            {
                desiredUser.IsActive = false;
            }

            this.data.SaveChanges();

            var session = SessionCreator.Create();

            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }

        public bool CheckIfRegisterModelIsValid(RegisterUserBindingModel model)
        {
            if (this.IsValidUsername(model.Username) && this.IsValidFullname(model.FullName) &&
                this.IsValidPassword(model.Password) && this.DoPasswordMatch(model.Password, model.ConfirmPassword))
            {
                bool isAnyone = this.IsAnyoneRegistered();
                var user = new User();

                if (!isAnyone)
                {
                    user.Username = model.Username;
                    user.FullName = model.FullName;
                    user.Password = model.Password;
                    user.RoleId = (int)UserRoleTypes.Administrator;

                    this.data.User.Add(user);
                }
                if (isAnyone)
                {
                    user.Username = model.Username;
                    user.FullName = model.FullName;
                    user.Password = model.Password;
                    user.RoleId = (int)UserRoleTypes.Regular;

                    this.data.User.Add(user);
                }

                this.data.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Not a valid binding model");
            }
        }

        private bool IsAnyoneRegistered()
        {
            return this.data.User.Query().Any();
        }

        private bool IsValidUsername(string username)
        {
            if (username.Length >= 5 && username.Length <= 30)
            {
                return true;
            }
            return false;
        }

        private bool IsValidFullname(string fullname)
        {
            if (fullname.Length >= 5)
            {
                return true;
            }
            return false;
        }

        private bool IsValidPassword(string password)
        {
            var isMatched = Regex.Match(password, @"^(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[!@#$%^&*,.]).{8,}$").Success;

            if (isMatched)
            {
                return true;
            }
            return false;
        }

        private bool DoPasswordMatch(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }
            return false;
        }
    }
}
