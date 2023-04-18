﻿using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using TestAec.API.Queries.Abstractions;
using TestAec.API.Queries.RawSql;
using TestAec.API.Requests;
using TestAec.Domain.Exceptions;

namespace TestAec.API.Queries.Concrete
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
