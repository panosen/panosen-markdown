// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Panosen.Markdown
{
    /// <summary>
    /// Specifies the type of Hyperlink that is used.
    /// </summary>
    public enum HyperlinkType
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// A hyperlink surrounded by angle brackets (e.g. "http://www.reddit.com").
        /// </summary>
        BracketedUrl = 301,

        /// <summary>
        /// A fully qualified hyperlink (e.g. "http://www.reddit.com").
        /// </summary>
        FullUrl = 302,

        /// <summary>
        /// A URL without a scheme (e.g. "www.reddit.com").
        /// </summary>
        PartialUrl = 303,

        /// <summary>
        /// An email address (e.g. "test@reddit.com").
        /// </summary>
        Email = 304,

        /// <summary>
        /// A subreddit link (e.g. "/r/news").
        /// </summary>
        Subreddit = 305,

        /// <summary>
        /// A user link (e.g. "/u/quinbd").
        /// </summary>
        User = 306,
    }
}