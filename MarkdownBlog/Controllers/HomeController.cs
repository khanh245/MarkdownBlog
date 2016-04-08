// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Ascension">
//   Copyright © Ascension 2016. All rights reserved.
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MarkdownBlog.Controllers
{
    using System.IO;
    using System.Web.Mvc;

    using MarkdownBlog.Core.Models;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Blog post under test.
        /// </summary>
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
            var file = new FileInfo(postPath);
            var text = System.IO.File.ReadAllText(postPath);

            this.blogPost = new BlogPost()
                                {
                                    Title = "Blog Post Title Goes Here",
                                    Content = text,
                                    CreatedDate = file.CreationTime.Date
                                };

            return this.View(this.blogPost);
        }
    }
}