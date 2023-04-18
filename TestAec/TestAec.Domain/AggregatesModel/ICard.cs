namespace TestAec.Domain.AggregatesModel
{
    public interface ICard
    {
        Task<Card> GetAsync(Guid id);
        Task<Card> AddAsync(Card item);

        void UpdateCard(Card item);
        void DeleteCard(Card item);
    }
}
