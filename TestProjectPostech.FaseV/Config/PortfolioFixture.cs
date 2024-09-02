using Bogus;
using PosTech.FaseV.Domain;

namespace TestProjectPostech.FaseV.Config
{
    [CollectionDefinition(nameof(PosTechFaseVCollectionPortfolio))]
    public class PosTechFaseVCollectionPortfolio : ICollectionFixture<PortfolioFixture> { }

    public class PortfolioFixture
    {
        private readonly Faker _faker = new Faker("pt_BR");

        public Portfolio Gerar_Portfolio_Valido()
        {
            return new Faker<Portfolio>()
                .CustomInstantiator(f =>
                    new Portfolio(
                        /*UserId     */ f.Random.AlphaNumeric(10),
                        /*Name       */ f.Random.Word(),
                        /*Description*/ f.Lorem.Sentence()
                    ));
        }

        public Portfolio Gerar_Portfolio_UserIdEmpty_Invalido()
        {
            return new Faker<Portfolio>()
                .CustomInstantiator(f =>
                    new Portfolio(
                        /*UserId     */ null,
                        /*Name       */ f.Random.Word(),
                        /*Description*/ f.Lorem.Sentence()
                    ));
        }

        public Portfolio Gerar_Portfolio_NameEmpty_Invalido()
        {
            return new Faker<Portfolio>()
                .CustomInstantiator(f =>
                    new Portfolio(
                        /*UserId     */ f.Random.AlphaNumeric(10),
                        /*Name       */ null,
                        /*Description*/ f.Lorem.Sentence()
                    ));
        }

        public Portfolio Gerar_Portfolio_NameInvalido_Invalido()
        {
            return new Faker<Portfolio>()
                .CustomInstantiator(f =>
                    new Portfolio(
                        /*UserId     */ f.Random.AlphaNumeric(10),
                        /*Name       */ "@#$%&*",
                        /*Description*/ f.Lorem.Sentence()
                    ));
        }

        public Portfolio Gerar_Portfolio_DescriptionMax150_Invalido()
        {
            return new Faker<Portfolio>()
                .CustomInstantiator(f =>
                    new Portfolio(
                        /*UserId     */ f.Random.AlphaNumeric(10),
                        /*Name       */ f.Random.Word(),
                        /*Description*/ f.Random.String(151)
                    ));
        }

        public Portfolio Gerar_Portfolio_DescriptionEspacos_Invalido()
        {
            return new Faker<Portfolio>()
                .CustomInstantiator(f =>
                    new Portfolio(
                        /*UserId     */ f.Random.AlphaNumeric(10),
                        /*Name       */ f.Random.Word(),
                        /*Description*/ "    " // Descrição inválida com apenas espaços em branco
                    ));
        }
    }
}
