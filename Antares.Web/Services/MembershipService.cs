using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Antares.Data;
using Antares.Web.Models;

namespace Antares.Web.Services
{
    public class MembershipService : IMembershipService
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<UserProfile> userRepository;
        private IGenericRepository<Role> roleRepository;

        public MembershipService(IUnitOfWork unitOfWork, IGenericRepository<UserProfile> userRepository, IGenericRepository<Role> roleRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            //this.userRepository = new GenericRepository<UserProfile>(unitOfWork);

        }

        public UserProfile GetUserById(int userId)
        {
            var user = userRepository.FindBy(u => u.UserId == userId).FirstOrDefault();
            return user;
        }

        public UserProfile GetUserByUserName(string userName)
        {
            var user = userRepository.FindBy(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
            return user;
        }

        public void Add(UserProfile user)
        {
            userRepository.Add(user);
            unitOfWork.Save();
        }

        public bool Login(string username, string password, bool persistCookie = false)
        {
            return WebSecurity.Login(username, password, persistCookie);
        }

        public void Logout()
        {
            WebSecurity.Logout();
        }

        public void SetRole(UserProfile user, int roleId)
        {
            var m = userRepository.FindBy(u => u.UserId == user.UserId).FirstOrDefault();
            var p = roleRepository.FindBy(r => r.RoleId == roleId).FirstOrDefault();
            m.Roles.Add(p);
            unitOfWork.Save();
        }
    }

    public interface IMembershipService
    {
        UserProfile GetUserById(int userId);
        UserProfile GetUserByUserName(string userName);
        void Add(UserProfile user);
        void SetRole(UserProfile user, int roleId);

        bool Login(string username, string password, bool persistCookie = false);
        void Logout();
    }

    public interface IAuthenticationService
    {
        bool SignIn(string userName, string password, bool rememberMe);
        bool SignOut();
    }

    public class WebSecurityAthenticationService : IAuthenticationService
    {
        private IPrincipal user;
        private IGenericRepository<UserProfile> userRepository;

        public WebSecurityAthenticationService(IPrincipal user, IGenericRepository<UserProfile> userRepository)
        {
            this.user = user;  // bind to HttpContext.Current.User
            this.userRepository = userRepository;
        }

        #region IAuthenticationService Members

        public bool SignIn(string userName, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }

        public bool SignOut()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}