namespace SelfFinanceApp.Api
{
    public static class ApiEndpoints
    {
        public const string ApiBase = "api";

        public static class FinancialTypes
        {
            public const string Base = $"{ApiBase}/financialTypes";

            public const string Create = $"{Base}";
            public const string GetAll = $"{Base}/getAll";
            public const string Get = $"{Base}/{{id:guid}}";
            public const string Update =  $"{Base}/{{id:Guid}}";
            public const string Delete = $"{Base}/{{id:Guid}}";
            public const string Patch = $"{Base}/{{id:Guid}}";
        }

        public static class FinancialOperations
        {
            public const string Base = $"{ApiBase}/financialOperations";

            public const string Create = $"{Base}/create";
            public const string GetMany = $"{Base}/getMany";
            public const string Get = $"{Base}/{{id:guid}}";
            public const string Update =  $"{Base}/{{id:Guid}}";
            public const string Delete = $"{Base}/{{id:Guid}}";
        }

        public static class Reports
        {
            public const string Base = $"{ApiBase}/reports";
            
            public const string GetMany = $"{Base}/get";
        }
    }
}
