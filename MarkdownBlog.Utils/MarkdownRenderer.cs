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
            var html = MarkdownTransformer.Transform(text);

            // Wrap the html in an MvcHtmlString otherwise it'll be HtmlEncoded and displayed to the user as HTML :(
            return new MvcHtmlString(html);
        }
    }
}
