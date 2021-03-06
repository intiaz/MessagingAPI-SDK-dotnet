/* 
 * Telstra Messaging API
 *
 *  The Telstra SMS Messaging API allows your applications to send and receive SMS text messages from Australia's leading network operator.  It also allows your application to track the delivery status of both sent and received SMS messages. 
 *
 * OpenAPI spec version: 2.2.4
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using com.telstra.messaging.Client;
using com.telstra.messaging.Api;
using com.telstra.messaging.Model;

namespace com.telstra.messaging.Test
{
    /// <summary>
    ///  Class for testing AuthApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class AuthApiTests
    {
        private AuthApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new AuthApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of AuthApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' AuthApi
            //Assert.IsInstanceOfType(typeof(AuthApi), instance, "instance is a AuthApi");
        }

        
        /// <summary>
        /// Test OauthTokenPost
        /// </summary>
        [Test]
        public void OauthTokenPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string oAuthClientId = null;
            //string oAuthClientSecret = null;
            //var response = instance.OauthTokenPost(oAuthClientId, oAuthClientSecret);
            //Assert.IsInstanceOf<AuthgeneratetokenpostResponse> (response, "response is AuthgeneratetokenpostResponse");
        }
        
    }

}
