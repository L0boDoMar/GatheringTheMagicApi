using GatheringTheMagic.Application.ExternalServices.DTOS.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace GatheringTheMagic.Application.UseCases.Cards.GetAllCard;

public sealed class GetAllCardsResponse
{
    public List<CardResponse> Cards { get; set; }
}
