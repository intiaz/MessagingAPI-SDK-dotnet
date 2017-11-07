/*
 * TelstraMessagingAPI.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using TelstraMessagingAPI.Standard;
using TelstraMessagingAPI.Standard.Utilities;
using TelstraMessagingAPI.Standard.Http.Request;
using TelstraMessagingAPI.Standard.Http.Response;
using TelstraMessagingAPI.Standard.Http.Client;
using TelstraMessagingAPI.Standard.Exceptions;

namespace TelstraMessagingAPI.Standard.Controllers
{
    public partial class MessagingController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static MessagingController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static MessagingController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new MessagingController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Send SMS
        /// </summary>
        /// <param name="payload">Required parameter: A JSON or XML payload containing the recipient's phone number and text message.  The recipient number should be in the format '04xxxxxxxx' where x is a digit</param>
        /// <return>Returns the Models.MessageSentResponse response from the API call</return>
        public Models.MessageSentResponse CreateSendSMS(Models.SendSMSRequest payload)
        {
            Task<Models.MessageSentResponse> t = CreateSendSMSAsync(payload);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Send SMS
        /// </summary>
        /// <param name="payload">Required parameter: A JSON or XML payload containing the recipient's phone number and text message.  The recipient number should be in the format '04xxxxxxxx' where x is a digit</param>
        /// <return>Returns the Models.MessageSentResponse response from the API call</return>
        public async Task<Models.MessageSentResponse> CreateSendSMSAsync(Models.SendSMSRequest payload)
        {
            //Check if authentication token is set
            AuthManager.Instance.CheckAuthorization();
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/messages/sms");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };
            _headers.Add("Authorization", string.Format("Bearer {0}", Configuration.OAuthToken.AccessToken));

            //append body params
            var _body = APIHelper.JsonSerialize(payload);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ErrorErrorErrorErrorErrorException(@"Invalid or missing request parameters", _context);

            if (_response.StatusCode == 401)
                throw new ErrorErrorErrorErrorErrorException(@"Invalid or no credentials passed in the request", _context);

            if (_response.StatusCode == 403)
                throw new ErrorErrorErrorErrorErrorException(@"Authorization credentials passed and accepted but account does not have permission", _context);

            if (_response.StatusCode == 404)
                throw new ErrorErrorErrorErrorErrorException(@"The requested URI does not exist", _context);

            if (_response.StatusCode == 405)
                throw new ErrorErrorErrorErrorErrorException(@"The requested resource does not support the supplied verb", _context);

            if (_response.StatusCode == 415)
                throw new ErrorErrorErrorErrorErrorException(@"API does not support the requested content type", _context);

            if (_response.StatusCode == 422)
                throw new ErrorErrorErrorErrorErrorException(@"The request is formed correctly, but due to some condition the request cannot be processed e.g. email is required and it is not provided in the request", _context);

            if (_response.StatusCode == 501)
                throw new ErrorErrorErrorErrorErrorException(@"The HTTP method being used has not yet been implemented for the requested resource", _context);

            if (_response.StatusCode == 503)
                throw new ErrorErrorErrorErrorErrorException(@"The service requested is currently unavailable", _context);

            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new ErrorErrorErrorErrorErrorException(@"An internal error occurred when processing the request", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.MessageSentResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get SMS Status
        /// </summary>
        /// <param name="messageId">Required parameter: Unique identifier of a message - it is the value returned from a previous POST call to https://api.telstra.com/v2/messages/sms</param>
        /// <return>Returns the List<Models.OutboundPollResponse> response from the API call</return>
        public List<Models.OutboundPollResponse> GetSMSStatus(string messageId)
        {
            Task<List<Models.OutboundPollResponse>> t = GetSMSStatusAsync(messageId);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get SMS Status
        /// </summary>
        /// <param name="messageId">Required parameter: Unique identifier of a message - it is the value returned from a previous POST call to https://api.telstra.com/v2/messages/sms</param>
        /// <return>Returns the List<Models.OutboundPollResponse> response from the API call</return>
        public async Task<List<Models.OutboundPollResponse>> GetSMSStatusAsync(string messageId)
        {
            //Check if authentication token is set
            AuthManager.Instance.CheckAuthorization();
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/messages/sms/{messageId}/status");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "messageId", messageId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };
            _headers.Add("Authorization", string.Format("Bearer {0}", Configuration.OAuthToken.AccessToken));

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ErrorErrorErrorErrorErrorException(@"Invalid or missing request parameters", _context);

            if (_response.StatusCode == 401)
                throw new ErrorErrorErrorErrorErrorException(@"Invalid or no credentials passed in the request", _context);

            if (_response.StatusCode == 403)
                throw new ErrorErrorErrorErrorErrorException(@"Authorization credentials passed and accepted but account does not have permission", _context);

            if (_response.StatusCode == 404)
                throw new ErrorErrorErrorErrorErrorException(@"The requested URI does not exist", _context);

            if (_response.StatusCode == 405)
                throw new ErrorErrorErrorErrorErrorException(@"The requested resource does not support the supplied verb", _context);

            if (_response.StatusCode == 415)
                throw new ErrorErrorErrorErrorErrorException(@"API does not support the requested content type", _context);

            if (_response.StatusCode == 422)
                throw new ErrorErrorErrorErrorErrorException(@"The request is formed correctly, but due to some condition the request cannot be processed e.g. email is required and it is not provided in the request", _context);

            if (_response.StatusCode == 501)
                throw new ErrorErrorErrorErrorErrorException(@"The HTTP method being used has not yet been implemented for the requested resource", _context);

            if (_response.StatusCode == 503)
                throw new ErrorErrorErrorErrorErrorException(@"The service requested is currently unavailable", _context);

            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new ErrorErrorErrorErrorErrorException(@"An internal error occurred when processing the request", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<List<Models.OutboundPollResponse>>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Send MMS
        /// </summary>
        /// <param name="body">Required parameter: A JSON or XML payload containing the recipient's phone number and MMS message.The recipient number should be in the format '04xxxxxxxx' where x is a digit</param>
        /// <return>Returns the dynamic response from the API call</return>
        public dynamic CreateSendMMS(Models.SendMMSRequest body)
        {
            Task<dynamic> t = CreateSendMMSAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Send MMS
        /// </summary>
        /// <param name="body">Required parameter: A JSON or XML payload containing the recipient's phone number and MMS message.The recipient number should be in the format '04xxxxxxxx' where x is a digit</param>
        /// <return>Returns the dynamic response from the API call</return>
        public async Task<dynamic> CreateSendMMSAsync(Models.SendMMSRequest body)
        {
            //Check if authentication token is set
            AuthManager.Instance.CheckAuthorization();
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/messages/mms");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };
            _headers.Add("Authorization", string.Format("Bearer {0}", Configuration.OAuthToken.AccessToken));

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new APIException(@"Invalid or missing request parameters", _context);

            if (_response.StatusCode == 401)
                throw new ErrorErrorErrorErrorErrorException(@"Invalid or no credentials passed in the request", _context);

            if (_response.StatusCode == 403)
                throw new ErrorErrorErrorErrorErrorException(@"Authorization credentials passed and accepted but account does not have permission", _context);

            if (_response.StatusCode == 404)
                throw new ErrorErrorErrorErrorErrorException(@"The requested URI does not exist", _context);

            if (_response.StatusCode == 405)
                throw new ErrorErrorErrorErrorErrorException(@"The requested resource does not support the supplied verb", _context);

            if (_response.StatusCode == 415)
                throw new ErrorErrorErrorErrorErrorException(@"API does not support the requested content type", _context);

            if (_response.StatusCode == 422)
                throw new ErrorErrorErrorErrorErrorException(@"The request is formed correctly, but due to some condition the request cannot be processed e.g. email is required and it is not provided in the request", _context);

            if (_response.StatusCode == 501)
                throw new ErrorErrorErrorErrorErrorException(@"The HTTP method being used has not yet been implemented for the requested resource", _context);

            if (_response.StatusCode == 503)
                throw new ErrorErrorErrorErrorErrorException(@"The service requested is currently unavailable", _context);

            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new ErrorErrorErrorErrorErrorException(@"An internal error occurred when processing the request", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Get MMS Status
        /// </summary>
        /// <param name="messageid">Required parameter: Unique identifier of a message - it is the value returned from a previous POST call to https://api.telstra.com/v2/messages/mms</param>
        /// <return>Returns the List<Models.OutboundPollResponse> response from the API call</return>
        public List<Models.OutboundPollResponse> GetMMSStatus(string messageid)
        {
            Task<List<Models.OutboundPollResponse>> t = GetMMSStatusAsync(messageid);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get MMS Status
        /// </summary>
        /// <param name="messageid">Required parameter: Unique identifier of a message - it is the value returned from a previous POST call to https://api.telstra.com/v2/messages/mms</param>
        /// <return>Returns the List<Models.OutboundPollResponse> response from the API call</return>
        public async Task<List<Models.OutboundPollResponse>> GetMMSStatusAsync(string messageid)
        {
            //Check if authentication token is set
            AuthManager.Instance.CheckAuthorization();
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/messages/mms/{messageid}/status");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "messageid", messageid }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };
            _headers.Add("Authorization", string.Format("Bearer {0}", Configuration.OAuthToken.AccessToken));

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ErrorErrorErrorErrorErrorException(@"Invalid or missing request parameters", _context);

            if (_response.StatusCode == 401)
                throw new ErrorErrorErrorErrorErrorException(@"Invalid or no credentials passed in the request", _context);

            if (_response.StatusCode == 403)
                throw new ErrorErrorErrorErrorErrorException(@"Authorization credentials passed and accepted but account does not have permission", _context);

            if (_response.StatusCode == 404)
                throw new ErrorErrorErrorErrorErrorException(@"The requested URI does not exist", _context);

            if (_response.StatusCode == 405)
                throw new ErrorErrorErrorErrorErrorException(@"The requested resource does not support the supplied verb", _context);

            if (_response.StatusCode == 415)
                throw new ErrorErrorErrorErrorErrorException(@"API does not support the requested content type", _context);

            if (_response.StatusCode == 422)
                throw new ErrorErrorErrorErrorErrorException(@"The request is formed correctly, but due to some condition the request cannot be processed e.g. email is required and it is not provided in the request", _context);

            if (_response.StatusCode == 501)
                throw new ErrorErrorErrorErrorErrorException(@"The HTTP method being used has not yet been implemented for the requested resource", _context);

            if (_response.StatusCode == 503)
                throw new ErrorErrorErrorErrorErrorException(@"The service requested is currently unavailable", _context);

            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new ErrorErrorErrorErrorErrorException(@"An internal error occurred when processing the request", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<List<Models.OutboundPollResponse>>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Retrieve SMS Responses
        /// </summary>
        /// <return>Returns the Models.InboundPollResponse response from the API call</return>
        public Models.InboundPollResponse RetrieveSMSResponses()
        {
            Task<Models.InboundPollResponse> t = RetrieveSMSResponsesAsync();
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve SMS Responses
        /// </summary>
        /// <return>Returns the Models.InboundPollResponse response from the API call</return>
        public async Task<Models.InboundPollResponse> RetrieveSMSResponsesAsync()
        {
            //Check if authentication token is set
            AuthManager.Instance.CheckAuthorization();
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/messages/sms");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };
            _headers.Add("Authorization", string.Format("Bearer {0}", Configuration.OAuthToken.AccessToken));

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new ErrorErrorErrorErrorErrorException(@"Invalid or missing request parameters", _context);

            if (_response.StatusCode == 401)
                throw new ErrorErrorErrorErrorErrorException(@"Invalid or no credentials passed in the request", _context);

            if (_response.StatusCode == 403)
                throw new ErrorErrorErrorErrorErrorException(@"Authorization credentials passed and accepted but account does not have permission", _context);

            if (_response.StatusCode == 404)
                throw new ErrorErrorErrorErrorErrorException(@"The requested URI does not exist", _context);

            if (_response.StatusCode == 405)
                throw new ErrorErrorErrorErrorErrorException(@"The requested resource does not support the supplied verb", _context);

            if (_response.StatusCode == 415)
                throw new ErrorErrorErrorErrorErrorException(@"API does not support the requested content type", _context);

            if (_response.StatusCode == 422)
                throw new ErrorErrorErrorErrorErrorException(@"The request is formed correctly, but due to some condition the request cannot be processed e.g. email is required and it is not provided in the request", _context);

            if (_response.StatusCode == 501)
                throw new ErrorErrorErrorErrorErrorException(@"The HTTP method being used has not yet been implemented for the requested resource", _context);

            if (_response.StatusCode == 503)
                throw new ErrorErrorErrorErrorErrorException(@"The service requested is currently unavailable", _context);

            if ((_response.StatusCode < 200) || (_response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new ErrorErrorErrorErrorErrorException(@"An internal error occurred when processing the request", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.InboundPollResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 