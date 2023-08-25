using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using System.Linq;

namespace OpenKuka.KRL.DataParser
{
    public static class KrlDataParser
    {
        public readonly static TokenListParser<KrlDataToken, Data> ScalarData =
            from name in Token.EqualTo(KrlDataToken.Key).OptionalOrDefault(new Token<KrlDataToken>(KrlDataToken.Key, new TextSpan("NoKey")))
            from token in Token.EqualTo(KrlDataToken.Bool)
                .Or(Token.EqualTo(KrlDataToken.Int))
                .Or(Token.EqualTo(KrlDataToken.Real))
                .Or(Token.EqualTo(KrlDataToken.Enum))
                .Or(Token.EqualTo(KrlDataToken.Char))
                .Or(Token.EqualTo(KrlDataToken.String))
            select (Data)(
                token.Kind == KrlDataToken.Bool ? new BoolData(name.ToStringValue(), token.ToStringValue()) :
                    token.Kind == KrlDataToken.Int ? new IntData(name.ToStringValue(), token.ToStringValue()) :
                        token.Kind == KrlDataToken.Real ? new RealData(name.ToStringValue(), token.ToStringValue()) :
                            token.Kind == KrlDataToken.Enum ? new EnumData(name.ToStringValue(), token.ToStringValue()) :
                                token.Kind == KrlDataToken.Char ? new CharData(name.ToStringValue(), token.ToStringValue()) :
                                    (Data)new StringData(name.ToStringValue(), token.ToStringValue()));

        public readonly static TokenListParser<KrlDataToken, Data> StrucData =
            from name in Token.EqualTo(KrlDataToken.Key).OptionalOrDefault(new Token<KrlDataToken>(KrlDataToken.Key, new TextSpan("NoKey")))
            from open in Token.EqualTo(KrlDataToken.LBracket)
            from type in Token.EqualTo(KrlDataToken.Type)
            from nodes in ScalarData.Try()
                .Or(StrucData) // .Or(Parse.Ref(() => StrucData))
                .ManyDelimitedBy(Token.EqualTo(KrlDataToken.Comma)) // , end: Token.EqualTo(MyToken.RBracket)
            from close in Token.EqualTo(KrlDataToken.RBracket)
            select (Data)(new StrucData(name.ToStringValue(), type.ToStringValue(), nodes));

        public readonly static TokenListParser<KrlDataToken, Data[]> Data =
            from nodes in ScalarData.Try()
                .Or(StrucData)
                .ManyDelimitedBy(Token.EqualTo(KrlDataToken.Comma))
            select nodes;

        public static TokenListParserResult<KrlDataToken, Data[]> TryParse(string input)
        {
            var tokenizer = KrlDataTokenizer.Instance;
            var tokens = tokenizer.Tokenize(input);
            var res = Data.TryParse(tokens);

            return res;
        }
    }
}
