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

namespace Antares.Web.Common
{
    public class MembershipService : IMembershipService
    {
        private IUnitOfWork unitOfWork;
        private IGenericRepository<UserProfile> userRepository;

        public MembershipService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = new GenericRepository<UserProfile>(unitOfWork);

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
    }

    public interface IMembershipService
    {
        UserProfile GetUserById(int userId);
        UserProfile GetUserByUserName(string userName);
        void Add(UserProfile user);
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