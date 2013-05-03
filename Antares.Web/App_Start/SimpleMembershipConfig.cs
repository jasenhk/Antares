using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Antares.Web.Models;

namespace Antares.Web
{
    public static class SimpleMembershipConfig
    {
        public static void Initialize()
        {
            try
            {
                if (!WebSecurity.Initialized)
                {
                    WebSecurity.InitializeDatabaseConnection(
                        connectionStringName: "AntaresContext",
                        userTableName: "UserProfile",
                        userIdColumn: "UserId",
                        userNameColumn: "UserName",
                        autoCreateTables: false
                        );
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET SimpleMembership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
}
