﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using PowerUtils.AspNetCore.ErrorHandler.Validations.Samples;
using Xunit;

namespace PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.Config
{
    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture> { }

    public class IntegrationTestsFixture : IDisposable
    {
        public HttpClient Client;

        private readonly WebAPIFactory<Startup> _factory;

        public IntegrationTestsFixture()
        {
            _factory = new WebAPIFactory<Startup>();

            Client = _factory.CreateClient();
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        }

        public void Dispose()
        {
            Client.Dispose();

            _factory.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
