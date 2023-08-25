using Superpower;
using Superpower.Display;
using Superpower.Model;
using Superpower.Parsers;
using Superpower.Tokenizers;
using System.Linq;

namespace OpenKuka.KRL.DataParser
{
    public enum KrlDataToken
    {
        // struct delimiters
        [Token(Example = "{")]
        LBracket,

        [Token(Example = "}")]
        RBracket,

        // field delimiters
        [Token(Example = ",")]
        Comma,

        // data
        Bool,
        Enum,
        Int,
        Real,
        Char,
        String,
        Type,
        Key,
    }

 

    public static class KrlDataTokenizer
    {
        public static TextParser<Unit> BooleanToken { get; } =
           from content in Span.EqualToIgnoreCase("false").Or(Span.EqualToIgnoreCase("true"))
           select Unit.Value;

        public static TextParser<Unit> IntegerToken { get; } =
           from sign in Character.EqualTo('-').OptionalOrDefault()
           from first in Character.Digit
           from rest in Character.Digit.IgnoreMany()
           select Unit.Value;

        public static TextParser<Unit> RealToken { get; } =
            from sign in Character.EqualTo('-').OptionalOrDefault()
            from first in Character.Digit
            from rest in Character.Digit.Or(Character.In('.', 'e', 'E', '+', '-')).IgnoreMany()
            select Unit.Value;

        public static TextParser<Unit> EnumToken { get; } =
            from first in Character.EqualTo('#')
            from second in Character.Letter.Or(Character.In('_', '$'))
            from rest in Character.LetterOrDigit.Or(Character.In('_', '$'))
                .IgnoreMany()
            select Unit.Value;

        public static TextParser<char> CharToken { get; } =
            from open in Character.EqualTo('"')
            from content in Character.Letter
            from close in Character.EqualTo('"')
            select content;

        public static TextParser<Unit> StringToken { get; } =
            from open in Character.EqualTo('"')
            from content in Span.EqualTo("\\\"").Value(Unit.Value).Try()
                .Or(Span.EqualTo("\\\\").Value(Unit.Value).Try())
                .Or(Character.Except('"').Value(Unit.Value))
                .IgnoreMany()
            from close in Character.EqualTo('"')
            select content;

        public static TextParser<Unit> TypeToken { get; } =
            from first in Character.Letter.Or(Character.In('_', '$'))
            from rest in Character.LetterOrDigit.Or(Character.In('_', '$')).IgnoreMany()
            from close in Character.EqualTo(':')
            select Unit.Value;

        public static TextParser<Unit> KeyToken { get; } =
            from first in Character.Letter.Or(Character.In('_', '$'))
            from rest in Character.Letter.Or(Character.Digit).Or(Character.In('_', '$', '[', ']'))
                .IgnoreMany()
            select Unit.Value;

        public static Tokenizer<KrlDataToken> Instance { get; } =
            new TokenizerBuilder<KrlDataToken>()
                .Ignore(Span.WhiteSpace)
                .Match(Character.EqualTo('{'), KrlDataToken.LBracket)
                .Match(Character.EqualTo('}'), KrlDataToken.RBracket)
                .Match(Character.EqualTo(','), KrlDataToken.Comma)
                .Match(CharToken, KrlDataToken.Char, requireDelimiters: false)
                .Match(StringToken, KrlDataToken.String, requireDelimiters: false)
                .Match(BooleanToken, KrlDataToken.Bool, requireDelimiters: true)
                .Match(IntegerToken, KrlDataToken.Int, requireDelimiters: true)
                .Match(RealToken, KrlDataToken.Real, requireDelimiters: true)
                .Match(EnumToken, KrlDataToken.Enum, requireDelimiters: true)
                .Match(TypeToken, KrlDataToken.Type, requireDelimiters: true)
                .Match(KeyToken, KrlDataToken.Key, requireDelimiters: true)
                .Build();
    }

}
