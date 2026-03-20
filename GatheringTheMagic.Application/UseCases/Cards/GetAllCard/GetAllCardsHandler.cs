using GatheringTheMagic.Application.ExternalServices;
using GatheringTheMagic.Application.ExternalServices.DTOS.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GatheringTheMagic.Application.UseCases.Cards.GetAllCard
{
    public sealed class GetAllCardsHandler : IRequestHandler<GetAllCardsRequest, GetAllCardsResponse>
    {
        private readonly IHttpClientService _httpClient;
        private readonly ILogger<GetAllCardsHandler> _logger;

        public GetAllCardsHandler(IHttpClientService httpClient, ILogger<GetAllCardsHandler> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<GetAllCardsResponse> Handle(GetAllCardsRequest request, CancellationToken cancellationToken)
        {
            var url = $"cards?page={request.page}&pageSize={request.itemsPerPage}";

            _logger.LogInformation($"GetCardsPaginado | Parâmetros: page-size: {request.itemsPerPage}, page: {request.page}", request);

            var response = await _httpClient.GetAsync<GetAllCardsResponse>(url);


            return response;
        }
    }
}
