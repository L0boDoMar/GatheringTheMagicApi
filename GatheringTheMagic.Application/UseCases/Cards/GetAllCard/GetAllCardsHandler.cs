using GatheringTheMagic.Application.ExternalServices;
using GatheringTheMagic.Application.ExternalServices.DTOS.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GatheringTheMagic.Application.UseCases.Cards.GetAllCard
{
    public sealed class GetAllCardsHandler : IRequestHandler<GetAllCardsRequest, GetAllCardsResponse>
    {
        private readonly IHttpClientService _httpClient;

        public GetAllCardsHandler(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetAllCardsResponse> Handle(GetAllCardsRequest request, CancellationToken cancellationToken)
        {
            var url = $"cards?page={request.page}&pageSize={request.itemsPerPage}";
            
            var response = await _httpClient.GetAsync<GetAllCardsResponse>(url);

            return response;
        }
    }
}
