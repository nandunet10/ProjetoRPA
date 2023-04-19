using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using TestAec.Domain.AggregatesModel;
using TestAec.Domain.AggregatesModel.ViewModel;
using TestAec.Domain.Exceptions;
using TestAec.Infrastructure.Queries.RawSql;

namespace TestAec.Infrastructure.Queries.Concrete
{
    public class CardQuery : ICardQuery
    {
        private readonly IConfiguration _configuration;

        public CardQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IApplicationResult<CardDetalhesViewModel>> ObterCardPorId(Guid cardId)
        {
            var result = new ApplicationResult<CardDetalhesViewModel>();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@cardId", cardId, DbType.Guid, ParameterDirection.Input);

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    var card = await connection.QueryFirstOrDefaultAsync<CardDetalhesViewModel>(CardRawSqls.ObterCardPorId, parameters);

                    result.Result = card;

                    connection.Close();
                }
            }
            catch (Exception)
            {
                result.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return result;
        }

        public async Task<IApplicationResult<IEnumerable<CardDetalhesViewModel>>> ObterCards()
        {
            var result = new ApplicationResult<IEnumerable<CardDetalhesViewModel>>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    var cards = await connection.QueryAsync<CardDetalhesViewModel>(CardRawSqls.ObterCards);

                    result.Result = cards;

                    connection.Close();
                }
            }
            catch (Exception)
            {
                result.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return result;
        }

    }
}
