using OpenKuka.KRL.Data.DOM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OpenKuka.KRL.Data.Parser
{
    public static class DataParser
    {
        public static List<IADSValue> Parse(string inputString)
        {
            return Parse(DataLexer.Tokenize(inputString));
        }

        /// <summary>
        /// Case 1 (single value) : VALUE
        /// Case 2 (array of values) : V1, V2, V3, V4, V5 with Vi all of same type
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        private static List<IADSValue> Parse(List<RegexToken<TokenType>> tokens)
        {
            int index = 0;
            int count = tokens.Count;

            var dataList = new List<IADSValue>();

            while (index < count)
            {
                var token = tokens[index];
                if (token.Type == TokenType.Comma) index++;
                var variable = ParseVariable(tokens, ref index, false);
                dataList.Add(variable.Value);
            }

            return dataList;
        }
        private static ADSVariable ParseVariable(List<RegexToken<TokenType>> tokens, ref int index, bool isIdentifierMandatory = true)
        {
            int count = tokens.Count;
            bool hasIdentifier = false;

            IADSValue value = null;
            string name = "";

            if (isIdentifierMandatory)
            {
                // we need at least two tokens to form a DataObject (id + value)
                if (index > count - 2)
                    throw new ArgumentException("expected : more tokens");

                // the first token must be the object identifier
                if (tokens[index].Type != TokenType.ID)
                    throw new ArgumentException("expected : identifier");

                hasIdentifier = true;
            }
            else
            {
                // we need at least one token to form a DataObject with no identifier
                if (index > count - 1)
                    throw new ArgumentException("expected : more tokens");

                // the first token is the object identifier
                if (tokens[index].Type == TokenType.ID)
                    hasIdentifier = true;
            }

            if (hasIdentifier)
            {
                name = tokens[index++].Value;

                // check if the identifier is followed by '[]'
                if (index + 1 < count)
                {
                    if (tokens[index].Type == TokenType.LSquareBracket)
                    {
                        if (tokens[index + 1].Type != TokenType.RSquareBracket)
                            throw new ArgumentException("expected : ']'");

                        // append '[]' to the identifier
                        name += "[]";
                        index++;
                        index++;
                    }
                }
            }

            if (index > count - 1)
                throw new ArgumentException("expected : token");

            
            var token = tokens[index];
            switch (token.Type)
            {
                case TokenType.BoolValue:
                    value = new BoolValue(token.Value);
                    index++;
                    break;

                case TokenType.IntNumber:
                    value = new IntValue(token.Value);
                    index++;
                    break;

                case TokenType.RealNumber:
                    value = new RealValue(token.Value);
                    index++;
                    break;

                case TokenType.NaN:
                    value = new RealValue(token.Value);
                    index++;
                    break;

                case TokenType.EnumValue:
                    value = new EnumValue(token.Value);
                    index++;
                    break;

                case TokenType.DoubleQuotedString:
                    var dq = token.Value.Trim('"');
                    if (dq.Length > 1) value = new StringValue(dq);
                    else value = new CharValue(dq);
                    index++;
                    break;

                case TokenType.SingleQuotedString:
                    var sq = token.Value.Trim('\'');
                    if (sq.Length > 1) value = new StringValue(sq);
                    else value = new CharValue(sq);
                    index++;
                    break;

                case TokenType.BitString:
                    value = new BitArrayValue(token.Value);
                    index++;
                    break;

                case TokenType.LCurlyBracket:
                    value = ParseStrucValue(tokens, ref index);
                    break;

                case TokenType.ID:
                    throw new ArgumentException("expected : value (got identifier)");

                case TokenType.Comma:
                    throw new ArgumentException("expected : value (got comma separator)");

                default:
                    throw new ArgumentException("expected : value");
            }

            return new ADSVariable() { Name = name, Value = value };
        }
        private static StrucValue ParseStrucValue(List<RegexToken<TokenType>> tokens, ref int index)
        {
            int count = tokens.Count;

            // consume the LCurlyBracket
            index++;

            string strucName = "";
            StrucValue data;

            if (index + 2 > count)
                throw new ArgumentException("expected : more tokens");

            if (tokens[index].Type != TokenType.ID)
                throw new ArgumentException("expected : identifier");

            // if the next token is a colon, then the identifier is for the struc type
            if (tokens[index + 1].Type == TokenType.Colon)
            {
                strucName = tokens[index].Value;
                index++;
                index++;
            }

            data = new StrucValue(strucName);

            while (index < count)
            {
                var token = tokens[index];
                if (token.Type == TokenType.RCurlyBracket) { index++; break; }
                if (token.Type == TokenType.Comma) index++;
                var variable = ParseVariable(tokens, ref index, true);
                data.Add(variable.Name, variable.Value);
            }

            return data;
        }
    }
}
