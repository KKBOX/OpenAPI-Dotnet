using System;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// KKBOX OAuth 2.0 Authorize Response.
    /// </summary>
    public class KKOAuthResponse
    {
        /// <summary>
        /// OAuth token data. <see cref="OAuthTokenData"/>
        /// </summary>
        public OAuthTokenData Content { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Response status. <see cref="APIStatus"/>
        /// </summary>
        public APIStatus Staus { get; set; }

        /// <summary>
        /// <see cref="System.Exception"/>
        /// </summary>
        public Exception Exception { get; set; }
        
        public KKOAuthResponse()
        {
            Staus = APIStatus.Unknow;
        }
    }
}