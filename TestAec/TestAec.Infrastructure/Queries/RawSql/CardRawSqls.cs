namespace TestAec.Infrastructure.Queries.RawSql
{
    public static class CardRawSqls
    {
        public static string ObterCards
        {
            get
            {
                return @"
                    SELECT [cardId]
                          ,[titulo]
                          ,[area]
                          ,[autor]
                          ,[descricao]
                          ,[dataPublicao]
                      FROM [DB_Automacao].[dbo].[Cards]
                ";
            }
        }


        public static string ObterCardPorId
        {
            get
            {
                return @"
                    SELECT [cardId]
                          ,[titulo]
                          ,[area]
                          ,[autor]
                          ,[descricao]
                          ,[dataPublicao]
                      FROM [DB_Automacao].[dbo].[Cards]
                      WHERE [cardId] = @cardId
                ";
            }
        }
    }
}
