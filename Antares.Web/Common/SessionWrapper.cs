using System;
using System.Collections.Generic;
using System.Web;

namespace Antares.Web
{
    public interface ISessionWrapper
    {

    }

    /// <summary>
    /// Strongly-typed Session items
    /// </summary>
    public class SessionWrapper : ISessionWrapper
    {
        private const string SessionKey = "__MySession__";

        private SessionWrapper()
        {
            // initialize and set default values
        }

        public static ISessionWrapper Current
        {
            get
            {
                ISessionWrapper session = (SessionWrapper)HttpContext.Current.Session[SessionKey];

                if (session == null)
                {
                    session = new SessionWrapper();
                    HttpContext.Current.Session[SessionKey] = session;
                }
                return session;
            }
        }

        #region Session Items

        // public Foo Foo { get; set; }

        #endregion
    }
}