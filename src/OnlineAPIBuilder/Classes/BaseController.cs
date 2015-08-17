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

        #region Public Methods

        [NonAction]
        public Dictionary<string, string> GetRequesData(params string[] routeParametersName)
        {
            var result = new Dictionary<string, string>();
            if (routeParametersName == null)
                routeParametersName = new string[0];
            var missingParameters = new List<string>();
            if (routeParametersName.Length > 0)
            {
                //If query string contains data, we will try to find all values in the query string, othewise we will look for the values in the route paramssss
                if (Request.QueryString != null && Request.QueryString.HasValue)
                {
                    foreach (var param in routeParametersName)
                    {
                        var qsValue = Request.Query[param] as string;
                        if (!string.IsNullOrEmpty(qsValue))
                            result.Add(param, qsValue);
                        else
                            missingParameters.Add(param);
                    }
                }
                else
                {
                    var firstAvailableUrlIndex = 5;
                    for (var i = 0; i < routeParametersName.Length; i++)
                    {
                        var param = routeParametersName[i];
                        var urlValue = Helper.GetUriSegment(Request, firstAvailableUrlIndex + i);
                        if (!string.IsNullOrEmpty(urlValue))
                            result.Add(param, urlValue);
                        else
                            missingParameters.Add(param);
                    }
                }
            }
            if (routeParametersName.Length != result.Count)
                throw new ArgumentException(string.Format("Please provide values for parameters \"{0}\"", string.Join(", ", missingParameters)));
            return result;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
