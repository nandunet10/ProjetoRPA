using TestAec.Domain.AggregatesModel.ViewModel;
using TestAec.Domain.Exceptions;

namespace TestAec.Domain.AggregatesModel
{
    public interface ICardQuery
    {
        Task<IApplicationResult<CardDetalhesViewModel>> ObterCardPorId(Guid cardId);
        Task<IApplicationResult<IEnumerable<CardDetalhesViewModel>>> ObterCards();
    }

}
