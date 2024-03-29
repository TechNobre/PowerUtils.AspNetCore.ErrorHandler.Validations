﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using PowerUtils.Text;

namespace PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.Utils
{
    internal static class HttpClientUtils
    {
        #region GETS
        public static async Task<(HttpResponseMessage Response, TResponse Content)> SendGetAsync<TResponse>(this HttpClient client, string endpoint, object parameters = null)
        {
            if(parameters != null)
            {
                endpoint += parameters.ToQueryString();
            }

            var response = await client
                .GetAsync(endpoint);

            return (
                response,
                await response.DeserializeResponseAsync<TResponse>()
            );
        }
        #endregion


        #region POSTS
        public static async Task<(HttpResponseMessage Response, TResponse Content)> SendPostAsync<TResponse>(this HttpClient client, string endpoint, object body = null)
        {
            var request = body.ToPostRequest(endpoint);

            var response = await client
                .SendAsync(request);

            return (
                response,
                await response.DeserializeResponseAsync<TResponse>()
            );
        }

        public static HttpRequestMessage ToPostRequest(this object body, string endpoint)
        {
            if(body == null)
            {
                return new HttpRequestMessage(HttpMethod.Post, endpoint)
                {
                    Content = JsonContent.Create(null, typeof(object), new MediaTypeHeaderValue(MediaTypeNames.Application.Json), null)
                };
            }

            return new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = JsonContent.Create(body)
            };
        }
        #endregion


        #region AUX
        public static async Task<TResponse> DeserializeResponseAsync<TResponse>(this HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();

            if(string.IsNullOrWhiteSpace(content))
            {
                return default;
            }

            try
            {
                return JsonSerializer.Deserialize<TResponse>(
                    content,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
            catch(Exception exception)
            {
                throw new InvalidCastException($"Cannot deserialize the response to {typeof(ErrorProblemDetails).FullName} Content -> {content}", exception);
            }
        }
        #endregion
    }
}
