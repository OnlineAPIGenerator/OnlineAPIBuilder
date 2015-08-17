using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Internal;

namespace OnlineAPIBuilder.Classes
{
    public class BaseController : Controller
    {
        #region Private Fields

        private string _client;
        private string _version;
        private string _callName;

        #endregion

        #region Public properties

        /// <summary>
        /// Getter: Returns requested Client identification taken from the url
        /// </summary>
        public string Client
        {
            get { return _client; }
        }

        /// <summary>
        /// Getter: Returns requested Client API version
        /// </summary>
        public string Version
        {
            get { return _version; }
        }

        /// <summary>
        /// Getter: Returns requested Client Call name from the url
        /// </summary>
        public string CallName
        {
            get { return _callName; }
        }

        #endregion

        #region Constructors

        public BaseController()
        {

        }

        #endregion

        #region Overrides

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _client = Helper.GetUriSegment(Request, 2);
            if (string.IsNullOrEmpty(_client) || string.IsNullOrWhiteSpace(_client))
                throw new ArgumentException(string.Format("Parameter \"{0}\" is not valid client"));

            _version = Helper.GetUriSegment(Request, 3);
            if (string.IsNullOrEmpty(_version) || string.IsNullOrWhiteSpace(_version))
                throw new ArgumentException(string.Format("Parameter \"{0}\" is not valid version number"));

            _callName = Helper.GetUriSegment(Request, 4);
            if (string.IsNullOrEmpty(_callName) || string.IsNullOrWhiteSpace(_callName))
                throw new ArgumentException(string.Format("Parameter \"{0}\" is not valid method to call"));
            base.OnActionExecuting(context);
        }

        #endregion
    }
}
