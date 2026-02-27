using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GatheringTheMagic.Application.UseCases.Cards.GetAllCard
{
    public record GetAllCardsRequest(string itemsPerPage, string page): IRequest<GetAllCardsResponse>;
}
