using Bogus;
using PosTech.FaseV.Domain;


namespace TestProjectPostech.FaseV.Config
{
    [CollectionDefinition(nameof(PosTechFaseVCollectionTransaction))]
    public class PosTechFaseVCollectionTransaction : ICollectionFixture<TransactionFixture> { }

    public class TransactionFixture
    {
        private readonly Faker _faker = new Faker("pt_BR");

        public Transaction Gerar_Transaction_Valida()
        {
            return new Faker<Transaction>()
                .CustomInstantiator(f =>
                    new Transaction(
                        /*TransactionType */ (int)TransactionType.Buy, // Valor válido do enum
                        /*Amount          */ f.Random.Decimal(1, 100),
                        /*Price           */ f.Random.Decimal(1, 100),
                        /*Portfolio       */ Gerar_Portfolio_Valido(),
                        /*Asset           */ Gerar_Asset_Valido()
                    ));
        }

        public Transaction Gerar_Transaction_TransactionTypeInvalido()
        {
            return new Faker<Transaction>()
                .CustomInstantiator(f =>
                    new Transaction(
                        /*TransactionType */ 999, // Valor inválido para o enum
                        /*Amount          */ f.Random.Decimal(1, 100),
                        /*Price           */ f.Random.Decimal(1, 100),
                        /*Portfolio       */ Gerar_Portfolio_Valido(),
                        /*Asset           */ Gerar_Asset_Valido()
                    ));
        }

        public Transaction Gerar_Transaction_AmountInvalido()
        {
            return new Faker<Transaction>()
                .CustomInstantiator(f =>
                    new Transaction(
                        /*TransactionType */ (int)TransactionType.Buy,
                        /*Amount          */ -1, // Valor inválido
                        /*Price           */ f.Random.Decimal(1, 100),
                        /*Portfolio       */ Gerar_Portfolio_Valido(),
                        /*Asset           */ Gerar_Asset_Valido()
                    ));
        }

        public Transaction Gerar_Transaction_PriceInvalido()
        {
            return new Faker<Transaction>()
                .CustomInstantiator(f =>
                    new Transaction(
                        /*TransactionType */ (int)TransactionType.Buy,
                        /*Amount          */ f.Random.Decimal(1, 100),
                        /*Price           */ -1, // Valor inválido
                        /*Portfolio       */ Gerar_Portfolio_Valido(),
                        /*Asset           */ Gerar_Asset_Valido()
                    ));
        }

        public Transaction Gerar_Transaction_PortfolioNulo()
        {
            return new Faker<Transaction>()
                .CustomInstantiator(f =>
                    new Transaction(
                        /*TransactionType */ (int)TransactionType.Buy,
                        /*Amount          */ f.Random.Decimal(1, 100),
                        /*Price           */ f.Random.Decimal(1, 100),
                        /*Portfolio       */ null, // Portfolio nulo
                        /*Asset           */ Gerar_Asset_Valido()
                    ));
        }

        public Transaction Gerar_Transaction_AssetNulo()
        {
            return new Faker<Transaction>()
                .CustomInstantiator(f =>
                    new Transaction(
                        /*TransactionType */ (int)TransactionType.Buy,
                        /*Amount          */ f.Random.Decimal(1, 100),
                        /*Price           */ f.Random.Decimal(1, 100),
                        /*Portfolio       */ Gerar_Portfolio_Valido(),
                        /*Asset           */ null // Asset nulo
                    ));
        }

        // Métodos auxiliares para gerar Portfolio e Asset válidos
        private Portfolio Gerar_Portfolio_Valido()
        {
            return new PortfolioFixture().Gerar_Portfolio_Valido();
        }

        private Asset Gerar_Asset_Valido()
        {
            return new AssetFixture().Gerar_Asset_Valido();
        }
    }
}
