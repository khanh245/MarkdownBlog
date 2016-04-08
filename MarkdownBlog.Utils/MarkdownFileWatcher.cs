// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarkdownFileWatcher.cs" company="Ascension">
//   Copyright © Ascension 2016. All rights reserved.
// </copyright>
// <summary>
//   Represents a markdown file watcher
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MarkdownBlog.Utils
{
    using System.IO;

    /// <summary>
    ///     Represents a markdown file watcher
    /// </summary>
    public class MarkdownFileWatcher
    {
        /// <summary>
        ///     The markdown file watcher.
        /// </summary>
        private FileSystemWatcher markdownWatcher;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MarkdownFileWatcher"/> class.
        /// </summary>
        /// <param name="path">The path to watch.</param>
        public MarkdownFileWatcher(string path)
        {
            this.markdownWatcher = new FileSystemWatcher(path)
                                       {
                                           EnableRaisingEvents = true,
                                           Filter = "*.md",
                                           NotifyFilter = NotifyFilters.LastAccess |
                                                          NotifyFilters.LastWrite |
                                                          NotifyFilters.FileName
                                        };
        }
    }
}
