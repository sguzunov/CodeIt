using System;

using Ganss.XSS;

namespace CodeIt.Web.Infrastructure.HtmlSanitisation
{
    public class HtmlContentSanitizer : ISanitizer
    {
        public Func<string, string> SanitizeContent
        {
            get
            {
                return (content) =>
                {
                    var sanitizer = new HtmlSanitizer();
                    var sanitizedContent = sanitizer.Sanitize(content);

                    return sanitizedContent;
                };
            }
        }
    }
}
