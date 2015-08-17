using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAPIBuilder.Classes
{
    public static class Helper
    {
        /// <summary>
        /// Not working: Needed for returning of the Request.RequestUri and its segments
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Generated Uri part of the Request</returns>
        public static Uri GetUri(HttpRequest request)
        {
            var builder = new UriBuilder();
            builder.Scheme = request.Scheme;
            builder.Host = request.Host.Value;
            builder.Path = request.Path;
            builder.Query = request.QueryString.ToUriComponent();
            return builder.Uri;
        }

        /// <summary>
        /// Parses segments from the Url path, null if segment is not found
        /// </summary>
        /// <param name="request">Basic HTTP Request</param>
        /// <param name="segmentNo">The number of the url segment that you wish to be retrieved</param>
        /// <returns>Segment of the url that you request, null if segment not found</returns>
        public static string GetUriSegment(HttpRequest request, int segmentNo)
        {
            var segments = request.Path.ToUriComponent().Split('/');

            if (segments.Length >= segmentNo + 1)
                return segments[segmentNo];
            return null;
        }
    }
}
