using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace empty1.BusinessLogic
{

    public class SessionHelper
    {
        public const string SESSION_START = "Session_Start";
        public const string SESSION_END = "Session_End";

        //GET data stroed under the current session.
        //This data is stored on the server in a collection.

        public DateTime Start {
            get {
                try
                {
                    return (DateTime)HttpContext.Current.Session[SESSION_START];

                }
                catch {
                    Intialize();
                }
                return (DateTime)HttpContext.Current.Session[SESSION_START];

            }
        }
        public DateTime End {
            get { return (DateTime)HttpContext.Current.Session[SESSION_END]; }
        }

        public string SessionID {
            get {
                if (HttpContext.Current.Session.SessionID != null)
                    return HttpContext.Current.Session.SessionID;
                return null;
            }
        }
        public void Intialize() {
            HttpContext.Current.Session[SESSION_START] = DateTime.Now;
            HttpContext.Current.Session[SESSION_END] = DateTime.Now.AddMinutes(1);
        }
        public void UpdateSession() {
            if (SessionID == null)
                Intialize();
            HttpContext.Current.Session[SESSION_END] = DateTime.Now.AddMinutes(1);
        }
        public void Clear() {
            if(SessionID != null){
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
            }
        }
    }
}