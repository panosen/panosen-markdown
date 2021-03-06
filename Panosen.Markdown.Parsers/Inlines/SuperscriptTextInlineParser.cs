// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.Toolkit.Parsers.Core;
using Panosen.Markdown.Inlines;
using Panosen.Markdown.Parser.Helpers;

namespace Panosen.Markdown.Parser.Inlines
{
    /// <summary>
    /// Represents a span containing superscript text.
    /// </summary>
    public class SuperscriptTextInlineParser
    {
        /// <summary>
        /// Returns the chars that if found means we might have a match.
        /// </summary>
        internal static void AddTripChars(List<InlineTripCharHelper> tripCharHelpers)
        {
            tripCharHelpers.Add(new InlineTripCharHelper() { FirstChar = '^', Method = InlineParseMethod.Superscript });
            tripCharHelpers.Add(new InlineTripCharHelper() { FirstChar = '<', Method = InlineParseMethod.Superscript });
        }

        /// <summary>
        /// Attempts to parse a superscript text span.
        /// </summary>
        /// <param name="markdown"> The markdown text. </param>
        /// <param name="start"> The location to start parsing. </param>
        /// <param name="maxEnd"> The location to stop parsing. </param>
        /// <returns> A parsed superscript text span, or <c>null</c> if this is not a superscript text span. </returns>
        internal static InlineParseResult Parse(string markdown, int start, int maxEnd)
        {
            // Check the first character.
            bool isHTMLSequence = false;
            if (start == maxEnd || (markdown[start] != '^' && markdown[start] != '<'))
            {
                return null;
            }

            if (markdown[start] != '^')
            {
                if (maxEnd - start < 5)
                {
                    return null;
                }
                else if (markdown.Substring(start, 5) != "<sup>")
                {
                    return null;
                }
                else
                {
                    isHTMLSequence = true;
                }
            }

            if (isHTMLSequence)
            {
                int innerStart = start + 5;
                int innerEnd, end;
                innerEnd = Common.IndexOf(markdown, "</sup>", innerStart, maxEnd);
                if (innerEnd == -1)
                {
                    return null;
                }

                if (innerEnd == innerStart)
                {
                    return null;
                }

                if (ParseHelpers.IsMarkdownWhiteSpace(markdown[innerStart]) || ParseHelpers.IsMarkdownWhiteSpace(markdown[innerEnd - 1]))
                {
                    return null;
                }

                // We found something!
                end = innerEnd + 6;
                var result = new SuperscriptTextInline();
                result.Inlines = Common.ParseInlineChildren(markdown, innerStart, innerEnd);
                return new InlineParseResult(result, start, end);
            }
            else
            {
                // The content might be enclosed in parentheses.
                int innerStart = start + 1;
                int innerEnd, end;
                if (innerStart < maxEnd && markdown[innerStart] == '(')
                {
                    // Find the end parenthesis.
                    innerStart++;
                    innerEnd = Common.IndexOf(markdown, ')', innerStart, maxEnd);
                    if (innerEnd == -1)
                    {
                        return null;
                    }

                    end = innerEnd + 1;
                }
                else
                {
                    // Search for the next whitespace character.
                    innerEnd = Common.FindNextWhiteSpace(markdown, innerStart, maxEnd, ifNotFoundReturnLength: true);
                    if (innerEnd == innerStart)
                    {
                        // No match if the character after the caret is a space.
                        return null;
                    }

                    end = innerEnd;
                }

                // We found something!
                var result = new SuperscriptTextInline();
                result.Inlines = Common.ParseInlineChildren(markdown, innerStart, innerEnd);
                return new InlineParseResult(result, start, end);
            }
        }
    }
}