// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Panosen.Markdown.Blocks;
using Panosen.Markdown.Parser.Helpers;
using Panosen.Markdown.Parser.Inlines;

namespace Panosen.Markdown.Parser.Blocks
{
    /// <summary>
    /// Represents a heading.
    /// <seealso href="https://spec.commonmark.org/0.29/#atx-headings">Single-Line Header CommonMark Spec</seealso>
    /// <seealso href="https://spec.commonmark.org/0.29/#setext-headings">Two-Line Header CommonMark Spec</seealso>
    /// </summary>
    public class HeaderBlockParser
    {
        /// <summary>
        /// Parses a header that starts with a hash.
        /// </summary>
        /// <param name="markdown"> The markdown text. </param>
        /// <param name="start"> The location of the first hash character. </param>
        /// <param name="end"> The location of the end of the line. </param>
        /// <returns> A parsed header block, or <c>null</c> if this is not a header. </returns>
        internal static HeaderBlock ParseHashPrefixedHeader(string markdown, int start, int end)
        {
            // This type of header starts with one or more '#' characters, followed by the header
            // text, optionally followed by any number of hash characters.
            var result = new HeaderBlock();

            // Figure out how many consecutive hash characters there are.
            int pos = start;
            while (pos < end && markdown[pos] == '#' && pos - start < 6)
            {
                pos++;
            }

            result.HeaderLevel = pos - start;
            if (result.HeaderLevel == 0)
            {
                return null;
            }

            // Ignore any hashes at the end of the line.
            while (pos < end && markdown[end - 1] == '#')
            {
                end--;
            }

            // Parse the inline content.
            result.Inlines = Common.ParseInlineChildren(markdown, pos, end);
            return result;
        }

        /// <summary>
        /// Parses a two-line header.
        /// </summary>
        /// <param name="markdown"> The markdown text. </param>
        /// <param name="firstLineStart"> The location of the start of the first line. </param>
        /// <param name="firstLineEnd"> The location of the end of the first line. </param>
        /// <param name="secondLineStart"> The location of the start of the second line. </param>
        /// <param name="secondLineEnd"> The location of the end of the second line. </param>
        /// <returns> A parsed header block, or <c>null</c> if this is not a header. </returns>
        internal static HeaderBlock ParseUnderlineStyleHeader(string markdown, int firstLineStart, int firstLineEnd, int secondLineStart, int secondLineEnd)
        {
            // This type of header starts with some text on the first line, followed by one or more
            // underline characters ('=' or '-') on the second line.
            // The second line can have whitespace after the underline characters, but not before
            // or between each character.

            // Check the second line is valid.
            if (secondLineEnd <= secondLineStart)
            {
                return null;
            }

            // Figure out what the underline character is ('=' or '-').
            char underlineChar = markdown[secondLineStart];
            if (underlineChar != '=' && underlineChar != '-')
            {
                return null;
            }

            // Read past consecutive underline characters.
            int pos = secondLineStart + 1;
            for (; pos < secondLineEnd; pos++)
            {
                char c = markdown[pos];
                if (c != underlineChar)
                {
                    break;
                }

                pos++;
            }

            // The rest of the line must be whitespace.
            for (; pos < secondLineEnd; pos++)
            {
                char c = markdown[pos];
                if (c != ' ' && c != '\t')
                {
                    return null;
                }

                pos++;
            }

            var result = new HeaderBlock();
            result.HeaderLevel = underlineChar == '=' ? 1 : 2;

            // Parse the inline content.
            result.Inlines = Common.ParseInlineChildren(markdown, firstLineStart, firstLineEnd);
            return result;
        }
    }
}