﻿using System.Collections.Generic;
using Microsoft.Toolkit.Parsers.Core;
using Panosen.Markdown.Inlines;
using Panosen.Markdown.Parser.Helpers;

namespace Panosen.Markdown.Parser.Inlines
{
    /// <summary>
    /// BoldTextInlineParser
    /// </summary>
    public class BoldTextInlineParser
    {
        /// <summary>
        /// Returns the chars that if found means we might have a match.
        /// </summary>
        internal static void AddTripChars(List<InlineTripCharHelper> tripCharHelpers)
        {
            tripCharHelpers.Add(new InlineTripCharHelper() { FirstChar = '*', Method = InlineParseMethod.Bold });
            tripCharHelpers.Add(new InlineTripCharHelper() { FirstChar = '_', Method = InlineParseMethod.Bold });
        }

        /// <summary>
        /// Attempts to parse a bold text span.
        /// </summary>
        /// <param name="markdown"> The markdown text. </param>
        /// <param name="start"> The location to start parsing. </param>
        /// <param name="maxEnd"> The location to stop parsing. </param>
        /// <returns> A parsed bold text span, or <c>null</c> if this is not a bold text span. </returns>
        internal static InlineParseResult Parse(string markdown, int start, int maxEnd)
        {
            if (start >= maxEnd - 1)
            {
                return null;
            }

            // Check the start sequence.
            string startSequence = markdown.Substring(start, 2);
            if (startSequence != "**" && startSequence != "__")
            {
                return null;
            }

            // Find the end of the span.  The end sequence (either '**' or '__') must be the same
            // as the start sequence.
            var innerStart = start + 2;
            int innerEnd = Common.IndexOf(markdown, startSequence, innerStart, maxEnd);
            if (innerEnd == -1)
            {
                return null;
            }

            // The span must contain at least one character.
            if (innerStart == innerEnd)
            {
                return null;
            }

            // The first character inside the span must NOT be a space.
            if (ParseHelpers.IsMarkdownWhiteSpace(markdown[innerStart]))
            {
                return null;
            }

            // The last character inside the span must NOT be a space.
            if (ParseHelpers.IsMarkdownWhiteSpace(markdown[innerEnd - 1]))
            {
                return null;
            }

            // We found something!
            var result = new BoldTextInline();
            result.Inlines = Common.ParseInlineChildren(markdown, innerStart, innerEnd);
            return new InlineParseResult(result, start, innerEnd + 2);
        }
    }
}
