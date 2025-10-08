using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditDataHub.Shared.Enums;
using CreditDataHub.Core.Models;
using CreditDataHub.Core.Interfaces;

namespace CreditDataHub.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly Dictionary<string, Token> _tokens = [];
        public void AddToken(Token token)
        {
            _tokens[token.TokenId] = token;
        }

        public TokenStatus UseToken(string token)
        {
            if(!_tokens.TryGetValue(token, out var existingToken))
                return TokenStatus.Invalid;

            if (existingToken.ExpiresAt < DateTime.UtcNow)
                return TokenStatus.Expired;

            if (existingToken.Used)
                return TokenStatus.Used;

            existingToken.Used = true;
            return TokenStatus.Used;
        }

        public TokenStatus ValidateToken(string token)
        {
            if(_tokens.TryGetValue(token, out var existingToken))
            {
                if(existingToken.Used)
                    return TokenStatus.Used;

                if(existingToken.ExpiresAt < DateTime.UtcNow)
                    return TokenStatus.Expired;

                return TokenStatus.Active;
            }
            return TokenStatus.Invalid;
        }
    }
}
