// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Ascension">
//   Home Controller
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MarkdownBlog.Controllers
{
    using System.Web.Mvc;

    using MarkdownBlog.Core.Models;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        private BlogPost blogPost;

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            var appdata = this.HttpContext.Server.MapPath("~/App_Data");
            var postPath = System.IO.Path.Combine(appdata, "posts/welcome-markdown.md");
            var text = System.IO.File.ReadAllText(postPath);
            this.blogPost = new BlogPost() { Title = "Test Blog Post", Content = text };

            return this.View(this.blogPost);
        }
    }
}