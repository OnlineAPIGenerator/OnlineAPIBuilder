using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace OnlineAPIBuilder.Classes
{
    public class BaseController : Controller
    {
        #region Public properties

        /// <summary>
        /// Getter: Returns requested Client identification taken from the url
        /// </summary>
        public string Client
        {
            get { return Helper.GetUriSegment(Request, 2); }
        }

        /// <summary>
        /// Getter: Returns requested Client API version
        /// </summary>
        public string Version
        {
            get { return Helper.GetUriSegment(Request, 3); }
        }

        /// <summary>
        /// Getter: Returns requested Client Call name from the url
        /// </summary>
        public string CallName
        {
            get { return Helper.GetUriSegment(Request, 4); }
        } 

        #endregion
    }
}
