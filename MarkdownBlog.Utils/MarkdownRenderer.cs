// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarkdownRenderer.cs" company="Ascension">
//   Markdown Renderer. An implementation by Danny Tuppeny. All rights reserved.
//   Link: http://blog.dantup.com/2011/03/an-asp-net-mvc-htmlhelper-extension-method-for-markdown-using-markdownsharp/
// </copyright>
// <summary>
//   Helper class for transforming Markdown.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MarkdownBlog.Utils
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;

    using MarkdownDeep;

    /// <summary>
    /// Helper class for transforming Markdown.
    /// </summary>
    public static class MarkdownRenderer
    {
        /// <summary>
        /// An instance of the Markdown class that performs the transformations.
        /// </summary>
        private static readonly Markdown MarkdownTransformer = new Markdown();

        /// <summary>
        /// Transforms a string of Markdown into HTML.
        /// </summary>
        /// <param name="helper">HtmlHelper - Not used, but required to make this an extension method.</param>
        /// <param name="text">The Markdown that should be transformed.</param>
        /// <returns>The HTML representation of the supplied Markdown.</returns>
        public static IHtmlString Markdown(this HtmlHelper helper, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            MarkdownTransformer.ExtraMode = true;
            MarkdownTransformer.SafeMode = false;

            // Transform the supplied text (Markdown) into HTML.
            var htmls = MarkdownTransformer.Transform(text).Split('\n');

            // Creating id link for html headers.
            for (int i = 0; i < htmls.Length; ++i)
            {
                const string Pattern = @"(<h[0-9]{1}.*?>)(.*?)(</h[0-9]{1}>)";

                if (!Regex.Match(htmls[i], Pattern).Success)
                {
                    continue;
                }

                var reg = new Regex(Pattern);
                var origHeaderString = reg.Match(htmls[i]).Groups[2].Value;
                var headerString = reg.Match(htmls[i]).Groups[2].Value.Replace(" ", "+");
                var headerStart = reg.Match(htmls[i]).Groups[1].Value.Replace(">", $" id=\"{headerString}\">");
                var headerEnd = reg.Match(htmls[i]).Groups[3].Value;

                htmls[i] = headerStart + origHeaderString + headerEnd;
            }

            // Jam everything back to a string.
            StringBuilder builder = new StringBuilder();
            foreach (var html in htmls)
            {
                builder.Append(html);
                builder.Append("\n");
            }

            // Wrap the html in an MvcHtmlString otherwise it'll be HtmlEncoded and displayed to the user as HTML :(
            return new MvcHtmlString(builder.ToString());
        }
    }
}
