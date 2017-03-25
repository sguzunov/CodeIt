using System;

namespace CodeIt.Web.Infrastructure.HtmlSanitisation
{
    public interface ISanitizer
    {
        Func<string, string> SanitizeContent { get; }
    }
}
