using TestAec.API.Requests;
using TestAec.Domain.Exceptions;

namespace TestAec.API.Queries.Abstractions
{
    public interface ICardQuery
    {
        Task<IApplicationResult<CardDetalhesViewModel>> ObterCardPorId(Guid cardId);
        Task<IApplicationResult<IEnumerable<CardDetalhesViewModel>>> ObterCards();
    }

}
