// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlogPost.cs" company="Ascension">
//   Copyright © Ascension 2016. All rights reserved.
// </copyright>
// <summary>
//   Represents a blog post
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MarkdownBlog.Core.Models
{
    using System;

    /// <summary>
    /// Represents a blog post
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost"/> class.
        /// </summary>
        public BlogPost()
        {
            this.Title = string.Empty;
            this.Content = string.Empty;
            this.CreatedDate = DateTime.Today.Date;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost"/> class.
        /// </summary>
        /// <param name="title">
        /// Blog post title
        /// </param>
        /// <param name="content">
        /// Blog post content
        /// </param>
        /// <param name="createdDate">
        /// Blog post created date
        /// </param>
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

            this.CreatedDate = createdDate;
        }

        /// <summary>
        /// Gets or sets the title of the blog post
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the blog post
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the created date of the blog post
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
