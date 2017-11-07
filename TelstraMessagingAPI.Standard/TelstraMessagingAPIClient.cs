/*
 * TelstraMessagingAPI.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using TelstraMessagingAPI.Standard.Controllers;
using TelstraMessagingAPI.Standard.Http.Client;
using TelstraMessagingAPI.Standard.Utilities;

namespace TelstraMessagingAPI.Standard
{
    public partial class TelstraMessagingAPIClient
    {

        /// <summary>
        /// Singleton access to Provisioning controller
        /// </summary>
        public ProvisioningController Provisioning
        {
            get
            {
                return ProvisioningController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to Messaging controller
        /// </summary>
        public MessagingController Messaging
        {
            get
            {
                return MessagingController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to OAuthAuthorization controller
        /// </summary>
        public OAuthAuthorizationController OAuthAuthorization
        {
            get
            {
                return OAuthAuthorizationController.Instance;
            }
        }
        /// <summary>
        /// The shared http client to use for all API calls
        /// </summary>
        public IHttpClient SharedHttpClient
        {
            get
            {
                return BaseController.ClientInstance;
            }
            set
            {
                BaseController.ClientInstance = value;
            }        
        }
        #region Authorization instance

        public AuthManager Auth
        {
            get { return AuthManager.Instance; }
        }

        #endregion
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public TelstraMessagingAPIClient() { }

        /// <summary>
        /// Client initialization constructor
        /// </summary>
        public TelstraMessagingAPIClient(string oAuthClientId, string oAuthClientSecret)
        {
            Configuration.OAuthClientId = oAuthClientId;
            Configuration.OAuthClientSecret = oAuthClientSecret;
        }
        #endregion
    }
}