using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenKuka.KRL.Data.Parser
{
    /// <summary>
    /// Tokens definition for parsing KrlDataObjects.
    /// </summary>
    public enum TokenType
    {
        // struct delimiters
        [Token(Pattern = @"\s+", Skip = true)]
        WhiteSpace,

        [Token(Pattern = @"[\+-]?[0-9]+\.[0-9]+([eE][\+-]?[0-9]+)?")]
        RealNumber,

        [Token(Pattern = @"[\+-]?[0-9]+")]
        IntNumber,

        [Token(Pattern = @"'B[01]+'")]
        BitString,

        [Token(Pattern = @"\""[^\""]*\""")]
        DoubleQuotedString,

        [Token(Pattern = @"'[^']*'")]
        SingleQuotedString,

        [Token(Pattern = @"#[a-zA-Z][a-zA-Z_0-9]{0,23}")]
        EnumValue,

        [Token(Pattern = @":")]
        Colon,

        [Token(Pattern = @",")]
        Comma,

        [Token(Pattern = @"\[")]
        LSquareBracket,

        [Token(Pattern = @"\]")]
        RSquareBracket,

        [Token(Pattern = @"\{")]
        LCurlyBracket,

        [Token(Pattern = @"\}")]
        RCurlyBracket,

        [Token(Pattern = @"TRUE|FALSE")]
        BoolValue,

        [Token(Pattern = @"NaN")]
        NaN,

        [Token(Pattern = @"[$a-zA-Z_][a-zA-Z_0-9]{0,23}")]
        ID,
    }

    /// <summary>
    /// Gets a strongly typed RegexLexer of type KrlDataTokenType.
    /// Use the Instance property.
    /// </summary>
    public static class DataLexer
    {
        public static List<RegexToken<TokenType>> Tokenize(string inputString)
        {
            return RegexLexer<TokenType>.Instance.Tokenize(inputString);
        }
    }
}
