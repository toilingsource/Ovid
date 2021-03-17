using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ovid.Data.Auth.Models.Config
{
    /// <summary>
    /// Claim Confirguration
    /// </summary>
    public static class ClaimConfig
    {



        private static List<Claim> _availableClaims;

        /// <summary>
        /// List of Avaible Claims
        /// </summary>
        public static List<Claim> AvailableClaims
        {
            get
            {
                if(_availableClaims == null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("account_type", "OVID-marketer"));
                    claims.Add(new Claim("account_type", "OVID-influencer"));
                    claims.Add(new Claim("account_type", "OVID-consumer"));

                    claims.Add(new Claim("CAN-ACCESS-CAMPIGNS", "false"));
                    claims.Add(new Claim("CAN-ACCESS-ADDS", "false"));
                    claims.Add(new Claim("CAN-ADD-CAMPIGNS", "value"));
                    claims.Add(new Claim("CAN-ADD-ADDS", "value"));
                    _availableClaims = claims;
                }
                return _availableClaims;
            }
        }

    }
}
