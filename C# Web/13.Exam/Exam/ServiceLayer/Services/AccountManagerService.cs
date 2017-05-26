using DataTransferObjects.BindingModels;
using DbEntities.Models;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ServiceLayer.Services
{
    public class AccountManagerService : Service, IAccountManagerService
    {
        public AccountManagerService(ISoftuniStoreData data)
            : base(data)
        {
        }


        public void Logout(HttpResponse response, string sessionId)
        {
            var login = this.Data.Logins.Query().FirstOrDefault(l => l.SessionId == sessionId && l.IsActive);

            if (login != null)
            {
                this.Data.Logins.Delete(login);
            }

            this.Data.SaveChanges();

            var session = SessionCreator.Create();

            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }

        #region Login

        public void IsLoginModelValid(HttpSession session, LoginBindingModel loginModel)
        {
            var user = this.VerifyUser(loginModel);

            if (user != null)
            {
                var login = this.Data.Logins.Query()
                    .FirstOrDefault(l => l.UserId == user.Id && l.SessionId == session.Id);

                if (login != null)
                {
                    login.IsActive = true;
                }
                else
                {
                    login = new Login()
                    {
                        IsActive = true,
                        UserId = user.Id,
                        SessionId = session.Id
                    };
                }

                this.Data.Logins.AddOrUpdate(login);
                this.Data.SaveChanges();
            }
        }

        private User VerifyUser(LoginBindingModel loginModel)
        {
            return this.Data.User.Query()
                .FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
        }

        #endregion

        #region Register

        public bool IsRegisterModelValid(RegisterBindingModel registerModel)
        {
            if (this.IsEmailValid(registerModel.Email) &&
                this.IsValidFullName(registerModel.FullName) &&
                this.IsPasswordValid(registerModel.Password) &&
                this.DoPasswordMatch(registerModel.Password, registerModel.ConfirmPassword))
            {
                bool isAnyOneRegistred = this.IsAnyOneRegistered();
                var user = new User();

                if (!isAnyOneRegistred)
                {
                    user.Email = registerModel.Email;
                    user.FullName = registerModel.FullName;
                    user.Password = registerModel.Password;
                    user.IsAdministrator = true;

                    this.Data.User.Add(user);
                }
                if (isAnyOneRegistred)
                {
                    user.Email = registerModel.Email;
                    user.FullName = registerModel.FullName;
                    user.Password = registerModel.Password;
                    user.IsAdministrator = false;

                    this.Data.User.Add(user);
                }

                this.Data.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Not a valid binding model");
            }
        }

        private bool IsAnyOneRegistered()
        {
            return this.Data.User.Query().Any();
        }

        private bool IsEmailValid(string email)
        {
            var isValidEmail = Regex.Match(email, "^\\S+@\\S+[\\.]\\S+$").Success;

            if (isValidEmail)
            {
                return true;
            }
            return false;
        }

        private bool IsPasswordValid(string password)
        {
            var isMatched = Regex.Match(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$").Success;

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

        private bool IsValidFullName(string fullName)
        {
            if (!string.IsNullOrEmpty(fullName))
            {
                return true;
            }
            return false;
        }



        #endregion
    }
}
