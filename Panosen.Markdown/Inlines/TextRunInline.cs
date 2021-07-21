// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.Markdown.Inlines
{
    /// <summary>
    /// Represents a span containing plain text.
    /// </summary>
    public class TextRunInline : MarkdownInline
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextRunInline"/> class.
        /// </summary>
        public TextRunInline()
            : base(MarkdownInlineType.TextRun)
        {
        }

        /// <summary>
        /// Gets or sets the text for this run.
        /// </summary>
        public string Text { get; set; }


        /// <summary>
        /// Converts the object into it's textual representation.
        /// </summary>
        /// <returns> The textual representation of this object. </returns>
        public override string ToString()
        {
            if (Text == null)
            {
                return base.ToString();
            }

            return Text;
        }
    }
}