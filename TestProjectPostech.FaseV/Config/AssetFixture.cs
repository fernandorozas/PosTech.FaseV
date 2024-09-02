
using Bogus;
using PosTech.FaseV.Domain;

namespace TestProjectPostech.FaseV.Config

{
    [CollectionDefinition(nameof(PosTechFaseVCollectionAsset))]
    public class PosTechFaseVCollectionAsset : ICollectionFixture<AssetFixture> { }

    public class AssetFixture
    {
        private readonly Faker _faker = new Faker("pt_BR");

        public Asset Gerar_Asset_Valido()
        {
            return new Faker<Asset>()
                .CustomInstantiator(f =>
                    new Asset(
                        /*Name      */ f.Lorem.Word(),
                        /*AssetType */ (int)AssetType.Stocks, // Valor válido do enum
                        /*Code      */ f.Random.AlphaNumeric(6)
                    ));
        }

        public Asset Gerar_Asset_NameEmpty_Invalido()
        {
            return new Faker<Asset>()
                .CustomInstantiator(f =>
                    new Asset(
                        /*Name      */ null,
                        /*AssetType */ (int)AssetType.Stocks,
                        /*Code      */ f.Random.AlphaNumeric(6)
                    ));
        }

        public Asset Gerar_Asset_CodeEmpty_Invalido()
        {
            return new Faker<Asset>()
                .CustomInstantiator(f =>
                    new Asset(
                        /*Name      */ f.Lorem.Word(),
                        /*AssetType */ (int)AssetType.Stocks,
                        /*Code      */ null
                    ));
        }

        public Asset Gerar_Asset_CodeInvalido_Invalido()
        {
            return new Faker<Asset>()
                .CustomInstantiator(f =>
                    new Asset(
                        /*Name      */ f.Lorem.Word(),
                        /*AssetType */ (int)AssetType.Stocks,
                        /*Code      */ "@#_4$" // Código com caracteres inválidos
                    ));
        }

        public Asset Gerar_Asset_CodeMax6Caracteres_Invalido()
        {
            return new Faker<Asset>()
                .CustomInstantiator(f =>
                    new Asset(
                        /*Name      */ f.Lorem.Word(),
                        /*AssetType */ (int)AssetType.Stocks,
                        /*Code      */ "1234567" // Código com mais de 6 caracteres
                    ));
        }


        public Asset Gerar_Asset_AssetTypeInvalido_Invalido()
        {
            return new Faker<Asset>()
                .CustomInstantiator(f =>
                    new Asset(
                        /*Name      */ f.Lorem.Word(),
                        /*AssetType */ 999, // Valor inválido para o enum
                        /*Code      */ f.Random.AlphaNumeric(6)
                    ));
        }
    }
}

