// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarkdownFileWatcher.cs" company="Ascension">
//   Markdown File Watcher
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
