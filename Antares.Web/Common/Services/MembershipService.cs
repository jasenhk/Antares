using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Antares.Data;
using Antares.Web.Models;

namespace Antares.Web.Common
{
    public class MembershipService
    {
        private GenericRepository<UserProfile> userRepository;

        public MembershipService()
        {
        }

        public UserInfo GetUserById(int userId)
        {
            var user = userRepository.FindBy(u => u.UserId == userId).FirstOrDefault();
            return null;
        }
    }
}