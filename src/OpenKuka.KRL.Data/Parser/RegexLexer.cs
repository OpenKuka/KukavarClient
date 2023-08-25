using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenKuka.KRL.Data.Parser
{
    // https://jack-vanlightly.com/blog/2016/2/24/a-more-efficient-regex-tokenizer
    // https://xoofx.com/blog/2017/02/06/stark-tokens-specs-and-the-tokenizer/
    // https://starbeamrainbowlabs.com/blog/article.php?article=posts/278-Building-A-Lexer-C-Sharp.html

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TokenAttribute : Attribute
    {
        public string Pattern { get; set; } = "";
        public bool Skip { get; set; } = false;
    }

    public class RegexToken<T> : Token<T> where T : System.Enum
    {
        public Match Match  { get; private set; }
        public override string Value => Match.Success ? Match.Value : "";

        public RegexToken(T type, Match match, bool skip = false):base(type, skip)
        {
            Match = match;
        }
    }
    public class RegexLexer<T> where T : System.Enum
    {
        private RegexLexerRule<T>[] _rules;
        public Regex _regex;

        public static readonly RegexLexer<T> Instance = new RegexLexer<T>();
        public string Pattern { get; private set; }

        protected RegexLexer()
        {
            // load rules
            Type type = typeof(T);
            var values = Enum.GetValues(type);

            _rules = new RegexLexerRule<T>[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                var value = (T)values.GetValue(i);
                var name = Enum.GetName(type, value);
                var field = type.GetField(name);
                var attribute = field.GetCustomAttributes(typeof(TokenAttribute), false)[0] as TokenAttribute;

                _rules[i] = new RegexLexerRule<T>(value, attribute.Pattern, attribute.Skip);
            }

            // combine rules
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(@"\G");
            stringBuilder.Append("(");
            for (int i = 0; i < _rules.Length; i++)
            {
                var rule = _rules[i];
                if (i > 0) stringBuilder.Append("|");
                stringBuilder.Append("(");
                stringBuilder.Append("?<" + rule.TokenType + ">");
                stringBuilder.Append(rule.Pattern);
                stringBuilder.Append(")");
            }
            stringBuilder.Append(")");
            Pattern = stringBuilder.ToString();
            _regex = new Regex(Pattern, RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Debug.WriteLine(Pattern);

        }
        public List<RegexToken<T>> Tokenize(string inputString)
        {
            var tokens = new List<RegexToken<T>>();
            int position = 0;
            while (true)
            {
                if (position >= inputString.Length) return tokens;

                var token = FindNextToken(inputString, position);
                if (token == null)
                {
                    break;
                }
                if (!token.Skip)
                {
                    tokens.Add(token);
                }
                position += token.Value.Length;
            }
            throw new Exception("Bad Token : " + inputString.Substring(position));
        }
        private RegexToken<T> FindNextToken(string inputString, int startIndex)
        {
            Match match = _regex.Match(inputString, startIndex);

            int tokenIndex = -1;
            T tokenType;
            for (int i = 0; i < _rules.Length; i++)
            {
                var rule = _rules[i];
                if (match.Groups[rule.TokenType.ToString()].Success)
                {
                    tokenIndex = i;
                    tokenType = rule.TokenType;
                    return new RegexToken<T>(tokenType, match, rule.Skip);
                }
            }

            return null;
        }

        private class RegexLexerRule<T> where T : System.Enum
        {
            public T TokenType { get; private set; }
            public string Pattern { get; private set; }
            public bool Skip { get; private set; }

            public RegexLexerRule(T tokenType, string pattern, bool skip = false)
            {
                Pattern = pattern;
                TokenType = tokenType;
                Skip = skip;
            }
        }
    }
}
