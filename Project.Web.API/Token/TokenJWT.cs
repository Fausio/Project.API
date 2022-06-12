﻿using System;
using System.IdentityModel.Tokens.Jwt;

namespace Project.Web.API.Token
{
    public class cc
    {
        private JwtSecurityToken _token;

        internal TokenJWT(JwtSecurityToken token)
        {
            this._token = token;
        }

        public DateTime ValidTo => _token.ValidTo;
        public string value => new JwtSecurityTokenHandler().WriteToken(this._token);
    }
}
