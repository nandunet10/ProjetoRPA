using Microsoft.EntityFrameworkCore;
using TestAec.Domain.AggregatesModel;
using TestAec.Infrastructure.Contexts;

namespace TestAec.Infrastructure.Repositories
{
    public class CardRepository : SqlServerRepository<Card>, ICard
    {
        private readonly Context _context;
        public CardRepository(Context context) : base(context)
        {
            _context = context;
        }
        private IQueryable<Card> GetCard()
        {
            return Entity;
        }
        public async Task<Card> AddAsync(Card item)
        {
            var result = await Entity.AddAsync(item);
            return result.Entity;
        }
        public async Task<Card> GetAsync(Guid id) => GetCard().FirstOrDefault(it => it.CardId == id);

        public void DeleteCard(Card item) => _context.Entry(item).State = EntityState.Deleted;

        public void UpdateCard(Card item) => _context.Entry(item).State = EntityState.Modified;

    }
}
