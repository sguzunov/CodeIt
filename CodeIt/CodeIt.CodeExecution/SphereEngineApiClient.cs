﻿using CodeIt.CodeExecution.Contracts;
using CodeIt.CodeExecution.Helpers.Contracts;
using CodeIt.CodeExecution.Models;
using System.Threading.Tasks;

namespace CodeIt.CodeExecution
{
    public class SphereEngineApiClient : ISphereEngineApiClient
    {
        private const string ApiBaseUrl = @"http://dfc5d4d0.compilers.sphere-engine.com/api/v3/submissions";

        private readonly string apiAccessToken;
        private readonly IHttpRequester requester;
        private readonly IJsonUtils jsonUtils;

        public SphereEngineApiClient(string apiAccessToken, IHttpRequester requester, IJsonUtils jsonUtils)
        {
            this.apiAccessToken = apiAccessToken;
            this.requester = requester;
            this.jsonUtils = jsonUtils;
        }

        public async Task<CodeExecutionResult> GetSubmissionResult(int id)
        {
            string url = ApiBaseUrl + $"/{id}" + $"?withSource=true&withStderr=true&withCmpinfo=true&withOutput=true&access_token={this.apiAccessToken}";
            return await this.requester.GetJsonAsync<CodeExecutionResult>(url);
        }

        public async Task<SubmissionIdentifyResult> Submit(SubmissionOptions options)
        {
            string url = ApiBaseUrl + $"?access_token={this.apiAccessToken}";
            string jsonData = this.jsonUtils.Serialize(options);
            return await this.requester.PostJsonAsync<SubmissionIdentifyResult>(url, jsonData);
        }
    }
}
