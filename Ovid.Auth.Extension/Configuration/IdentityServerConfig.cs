using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ovid.Auth.Extension.Configuration
{
    public class IdentityServerConfig
    {
        public const string ApiName = "ovid_api";
        public const string ApiFriendlyName = "Ovid API";
        public const string SpaAppId = "ovid_spa";
        public const string ChatClientId = "ovid_chat";
        public const string ChatClientName = "Ovid Chat Client";
        public const string MobileClientId = "ovid_mobile";
        public const string MobileClientName = "Ovid Mobile Client";
        public const string SwaggerClientID = "swaggerui";
        public const string ApiClientId = "ovid_grpah";

        // Identity resources (used by UserInfo endpoint).
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResources.Email(),
                new IdentityResource(ScopeConstants.Roles, new List<string> { JwtClaimTypes.Role })
            };
        }

        // Api resources.
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(ApiName) {
                    UserClaims = {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.PhoneNumber,
                        JwtClaimTypes.Role,
                        ClaimConstants.Permission
                    }
                }
            };
        }

        // Clients want to access resources.
        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            // Clients credentials.
            return new List<Client>
            {
                // http://docs.identityserver.io/en/release/reference/client.html.
                new Client
                {
                    ClientId = IdentityServerConfig.SpaAppId,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, // Resource Owner Password Credential grant.
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins=new List<string>{"https://localhost:4200", "http://localhost:4200", "https://localhost:5001", "http://localhost:5000", "https://keeper.mj-2.com"},
                    RequireClientSecret = false, // This client does not need a secret to request tokens from the token endpoint.
                    
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId, // For UserInfo endpoint.
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        ScopeConstants.Roles,
                        ApiName
                    },
                    AllowOfflineAccess = true, // For refresh token.
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                },

                new Client
                {
                    ClientId = IdentityServerConfig.ChatClientId,
                    ClientName = IdentityServerConfig.ChatClientName,
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("FF55C563-8426-44A0-AE31-B0BE8CFBE8B4".ToSha256())
                    },

                    AllowedCorsOrigins=new List<string>{"https://localhost:4200", "http://localhost:4200", "https://localhost:5001", "http://localhost:5000", "https://keeper.mj-2.com"},

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId, // For UserInfo endpoint.
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        ScopeConstants.Roles,
                        ApiName
                    },
                    AllowOfflineAccess = true, // For refresh token.
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                },

                new Client
                {
                    ClientId = IdentityServerConfig.ApiClientId,
                    ClientName = IdentityServerConfig.ApiFriendlyName,
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("FF55C563-8426-44A0-AE31-B0BE8CFBE8B4".ToSha256())
                    },

                    AllowedCorsOrigins=new List<string>{"https://localhost:4200", "http://localhost:4200", "https://localhost:5001", "http://localhost:5000", "https://keeper.mj-2.com"},

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId, // For UserInfo endpoint.
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        ScopeConstants.Roles,
                        ApiName
                    },
                    AllowOfflineAccess = true, // For refresh token.
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                },

                new Client
                {
                    ClientId = IdentityServerConfig.MobileClientId,
                    ClientName = IdentityServerConfig.MobileClientName,
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "ovid://callback" },
                    RequireClientSecret=false,
                    //ClientSecrets =
                    //{
                    //    new Secret("FF55C563-8426-44A0-AE31-B0BE8CFBE8B4".ToSha256())
                    //},

                    AllowedCorsOrigins=new List<string>{ "https://localhost:4200", "http://localhost:4200", "https://localhost:5001", "http://localhost:5000", "https://keeper.mj-2.com", "ovid://callback"},

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId, // For UserInfo endpoint.
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        ScopeConstants.Roles,
                        ApiName
                    },
                    AllowOfflineAccess = true, // For refresh token.
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                },

                new Client
                {
                    ClientId = SwaggerClientID,
                    ClientName =  "Swagger UI",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowAccessTokensViaBrowser = true,
                    RequireClientSecret = false,

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId, // For UserInfo endpoint.
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Email,
                        ApiName
                    }
                }
            };
        }
    }
}
