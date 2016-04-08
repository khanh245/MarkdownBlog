// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlogPostTests.cs" company="Ascension">
//   Copyright © Ascension 2016. All rights reserved.
// </copyright>
// <summary>
//   Blog post tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MarkdownBlog.NUnit.Tests
{
    using System;

    using Core.Models;

    using FluentAssertions;

    using global::NUnit.Framework;

    /// <summary>
    /// Blog post tests.
    /// </summary>
    [TestFixture]
    [Category("Blog Post Tests")]
    internal class BlogPostTests
    {
        /// <summary>
        /// The expected blog title.
        /// </summary>
        private const string BlogTitle = "This is the title";

        /// <summary>
        /// The expected blog content.
        /// </summary>
        private const string BlogContent = "This is the content";

        /// <summary>
        /// The expected created date.
        /// </summary>
        private readonly DateTime blogCreatedDate = DateTime.Today;

        /// <summary>
        /// The blog post to be tested.
        /// </summary>
        private BlogPost blogPost;

        /// <summary>
        /// Should create an empty post with today date.
        /// </summary>
        [Test]
        public void ShouldCreateEmptyPostWithTodayDate()
        {
            this.GivenAnEmptyBlogPost();
            this.ThenTheTitleAndContentShouldBeEmpty();
        }

        /// <summary>
        /// Should get post with expected values.
        /// </summary>
        /// <remarks>Values are known and defined above</remarks>
        [Test]
        public void ShouldGetPostWithValues()
        {
            this.GivenABlogPostWithValues(BlogTitle, BlogContent, this.blogCreatedDate);
            this.ThenTheBlogPropertiesShouldMatch();
        }

        /// <summary>
        /// Should be able to set properties of an empty blog post.
        /// </summary>
        [Test]
        public void ShouldBeAbleToSetPropertiesOfBlogPost()
        {
            this.GivenAnEmptyBlogPost();
            this.WhenSettingPropertiesForTheBlogPost();
            this.ThenTheBlogPropertiesShouldMatch();
        }

        /// <summary>
        /// Given an empty blog post.
        /// </summary>
        private void GivenAnEmptyBlogPost()
        {
            this.blogPost = new BlogPost();
        }

        /// <summary>
        /// Given a blog post with values.
        /// </summary>
        /// <param name="title">The blog post title</param>
        /// <param name="content">The blog post content</param>
        /// <param name="createdDate">The blog post created date</param>
        private void GivenABlogPostWithValues(string title, string content, DateTime createdDate)
        {
            this.blogPost = new BlogPost(title, content, createdDate);
        }

        /// <summary>
        /// When setting properties for the blog post.
        /// </summary>
        private void WhenSettingPropertiesForTheBlogPost()
        {
            this.blogPost.Title = BlogTitle;
            this.blogPost.CreatedDate = this.blogCreatedDate;
            this.blogPost.Content = BlogContent;
        }

        /// <summary>
        /// Then the title and content should be empty.
        /// </summary>
        private void ThenTheTitleAndContentShouldBeEmpty()
        {
            this.blogPost.Title.Should().BeNullOrEmpty();
            this.blogPost.Content.Should().BeNullOrEmpty();
        }

        /// <summary>
        /// Then the blog's properties should match.
        /// </summary>
        private void ThenTheBlogPropertiesShouldMatch()
        {
            this.blogPost.Title.Should().Be(BlogTitle);
            this.blogPost.Content.Should().Be(BlogContent);
            this.blogPost.CreatedDate.Should().Be(this.blogCreatedDate);
        }
    }
}
