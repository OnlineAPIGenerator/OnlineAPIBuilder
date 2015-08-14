using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAPIBuilder.Classes
{
    public static class Helper
    {
        public static Uri GetUri(HttpRequest request)
        {
            var builder = new UriBuilder();
            builder.Scheme = request.Scheme;
            builder.Host = request.Host.Value;
            builder.Path = request.Path;
            builder.Query = request.QueryString.ToUriComponent();
            return builder.Uri;
        }

        public static string GetUriSegment(HttpRequest request, int segmentNo)
        {
            var segments = request.Path.ToUriComponent().Split('/');
            return segments[segmentNo];
        }
    }
}
