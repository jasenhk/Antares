using System;
using System.Collections.Generic;
using System.Web;

namespace Antares.Web.Common
{
    public interface ISessionWrapper
    {
        //DateTime TimeStarted { get; set; }
    }

    /// <summary>
    /// Strongly-typed Session items
    /// </summary>
    public class SessionWrapper : ISessionWrapper
    {
        private const string SessionKey = "__MySession__";
        //private readonly DateTime timeStarted;

        private SessionWrapper()
        {
            // initialize and set default values
            //this.timeStarted = DateTime.Now;
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

        //public DateTime TimeStarted { get; set; }

        #endregion
    }
}