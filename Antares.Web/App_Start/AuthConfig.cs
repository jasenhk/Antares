using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Antares.Web.Models;

namespace Antares.Web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            #region OAuth Providers

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            #endregion

            #region OpenID Providers

            //OAuthWebSecurity.RegisterGoogleClient();
            //OAuthWebSecurity.RegisterYahooClient();

            #endregion

            try
            {
                WebSecurity.InitializeDatabaseConnection(
                    connectionStringName: "AntaresContext",
                    userTableName: "UserProfile",
                    userIdColumn: "UserId",
                    userNameColumn: "UserName",
                    autoCreateTables: false
                    );
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET SimpleMembership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
}
