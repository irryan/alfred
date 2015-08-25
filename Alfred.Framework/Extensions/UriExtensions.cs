using System;
using System.Linq;
using System.Net;
using System.Text;

namespace Alfred.Framework.Extensions
{
    public static class UriExtensions
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            var ub = new UriBuilder(uri);

            var httpValueCollection = uri.Query.TrimStart('?').Split(new[] { '&', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(part =>
            {
                var nvp = part.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                return new
                {
                    Name = WebUtility.UrlDecode(nvp[0]),
                    Value = WebUtility.UrlDecode(nvp[1]),
                };
            }).ToList();
            httpValueCollection.Add(new { Name = name, Value = value });

            if (httpValueCollection.Count == 0)
            {
                ub.Query = string.Empty;
            }
            else
            {
                var sb = new StringBuilder();

                foreach (var httpValue in httpValueCollection)
                {
                    var n = WebUtility.UrlEncode(httpValue.Name);
                    var val = (n != null) ? n + "=" : string.Empty;
                    string[] vals = httpValueCollection.Where(kvp => kvp.Name == n).Select(kvp => kvp.Value).ToArray();

                    if (sb.Length > 0)
                    {
                        sb.Append("&");
                    }

                    if (vals == null || vals.Length == 0)
                    {
                        sb.Append(val);
                    }
                    else
                    {
                        if (vals.Length == 1)
                        {
                            sb.Append(val);
                            sb.Append(WebUtility.UrlEncode(vals[0]));
                        }
                        else
                        {
                            sb.Append(string.Join("&", vals.Select(entry =>
                                string.Format("{0}={1}", val, WebUtility.UrlEncode(entry)))));
                        }
                    }
                }

                ub.Query = sb.ToString();
            }

            return ub.Uri;
        }
    }
}
