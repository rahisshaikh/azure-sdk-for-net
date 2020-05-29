// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Iot.Hub.Service
{
    internal partial class HttpRuntimeRestClient
    {
        private Uri endpoint;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of HttpRuntimeRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> This occurs when one of the required arguments is null. </exception>
        public HttpRuntimeRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, string apiVersion = "2020-03-13")
        {
            endpoint ??= new Uri("https://fully-qualified-iothubname.azure-devices.net");
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            this.endpoint = endpoint;
            this.apiVersion = apiVersion;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateReceiveFeedbackNotificationRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/messages/serviceBound/feedback", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            return message;
        }

        /// <summary> This method is used to retrieve feedback of a cloud-to-device message See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging for more information. This capability is only available in the standard tier IoT Hub. For more information, see [Choose the right IoT Hub tier](https://aka.ms/scaleyouriotsolution). For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ReceiveFeedbackNotificationAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateReceiveFeedbackNotificationRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> This method is used to retrieve feedback of a cloud-to-device message See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging for more information. This capability is only available in the standard tier IoT Hub. For more information, see [Choose the right IoT Hub tier](https://aka.ms/scaleyouriotsolution). For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response ReceiveFeedbackNotification(CancellationToken cancellationToken = default)
        {
            using var message = CreateReceiveFeedbackNotificationRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCompleteFeedbackNotificationRequest(string lockToken)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/messages/serviceBound/feedback/", false);
            uri.AppendPath(lockToken, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            return message;
        }

        /// <summary> This method completes a feedback message. The lockToken obtained when the message was received must be provided to resolve race conditions when completing, a feedback message. A completed message is deleted from the feedback queue. See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging for more information. For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="lockToken"> Lock token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> CompleteFeedbackNotificationAsync(string lockToken, CancellationToken cancellationToken = default)
        {
            if (lockToken == null)
            {
                throw new ArgumentNullException(nameof(lockToken));
            }

            using var message = CreateCompleteFeedbackNotificationRequest(lockToken);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> This method completes a feedback message. The lockToken obtained when the message was received must be provided to resolve race conditions when completing, a feedback message. A completed message is deleted from the feedback queue. See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging for more information. For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="lockToken"> Lock token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CompleteFeedbackNotification(string lockToken, CancellationToken cancellationToken = default)
        {
            if (lockToken == null)
            {
                throw new ArgumentNullException(nameof(lockToken));
            }

            using var message = CreateCompleteFeedbackNotificationRequest(lockToken);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAbandonFeedbackNotificationRequest(string lockToken)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/messages/serviceBound/feedback/", false);
            uri.AppendPath(lockToken, true);
            uri.AppendPath("/abandon", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            return message;
        }

        /// <summary> This method abandons a feedback message. The lockToken obtained when the message was received must be provided to resolve race conditions when abandoning, a feedback message. A abandoned message is deleted from the feedback queue. See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging for more information. For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="lockToken"> Lock Token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> AbandonFeedbackNotificationAsync(string lockToken, CancellationToken cancellationToken = default)
        {
            if (lockToken == null)
            {
                throw new ArgumentNullException(nameof(lockToken));
            }

            using var message = CreateAbandonFeedbackNotificationRequest(lockToken);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> This method abandons a feedback message. The lockToken obtained when the message was received must be provided to resolve race conditions when abandoning, a feedback message. A abandoned message is deleted from the feedback queue. See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging for more information. For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="lockToken"> Lock Token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response AbandonFeedbackNotification(string lockToken, CancellationToken cancellationToken = default)
        {
            if (lockToken == null)
            {
                throw new ArgumentNullException(nameof(lockToken));
            }

            using var message = CreateAbandonFeedbackNotificationRequest(lockToken);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}