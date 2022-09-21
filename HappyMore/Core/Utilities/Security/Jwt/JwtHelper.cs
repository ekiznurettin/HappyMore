using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
           // _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();  
        }

        public AccessToken CreateToken(User user, IList<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCerdentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CerateJwtSecurityToken(_tokenOptions, user, signingCerdentials, operationClaims);
            var jwtSecurityTokenHelper = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHelper.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }


        public JwtSecurityToken CerateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, IList<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
               issuer: tokenOptions.Issuer,
               audience: tokenOptions.Audience,
               expires: _accessTokenExpiration,
               notBefore: DateTime.Now,
               claims: SetClaims(user, operationClaims),
               signingCredentials: signingCredentials);
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, IList<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.UserId.ToString());
            claims.AddEmail(user.Mail.ToString());
            claims.AddName($"{user.Name} {user.Surname}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
