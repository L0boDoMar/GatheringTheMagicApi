using GatheringTheMagic.Application.ExternalServices.DTOS.Response;

namespace GatheringTheMagic.Application.UseCases.Cards.GetAllCard;

public sealed record GetAllCardsResponse
{
    public List<CardResponse> Cards { get; set; }
}
