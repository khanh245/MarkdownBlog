using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace MarkdownBlog.Core.Models
{
    /// <summary>
    /// Represents a blog post
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// The title of the blog post
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content of the blog post
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The created date of the blog post
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Instantiates an instance of an empty blog post
        /// </summary>
        public BlogPost()
        {
            Title = string.Empty;
            Content = string.Empty;
            CreatedDate = DateTime.Today.Date;
        }

        /// <summary>
        /// Instantiates an instance of a blog post
        /// </summary>
        /// <param name="title">Blog post title</param>
        /// <param name="content">Blog post content</param>
        /// <param name="createdDate">Blog post created date</param>
        public BlogPost(string title, string content, DateTime createdDate)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            CreatedDate = createdDate;
        }
    }
}
