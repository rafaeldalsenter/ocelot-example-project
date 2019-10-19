using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ocelot.Example.Gateway.Handlers
{
    public class BlackListHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.TryGetValues("CLIENT_ID", out var values);
            var clientId = values?.FirstOrDefault();

            if (clientId is null)
            {
                return ReturnBadRequest("Request bloqueada por falta de informações");
            }

            if (_blackList.Any(x => x.Equals(clientId)))
            {
                return ReturnBadRequest("Request bloqueada pela BlackList");
            }

            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> ReturnBadRequest(string message) =>
            Task.Factory.StartNew(() =>
                new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(message)
                });

        private List<string> _blackList => new List<string>
        {
            "CLIENT1",
            "CLIENT3"
        };
    }
}