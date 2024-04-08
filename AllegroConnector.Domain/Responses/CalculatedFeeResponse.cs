namespace AllegroConnector.Domain.Responses
{
    public class CalculatedFeeResponse
    {
        public List<Commission> commissions { get; set; }
        public List<Quote> quotes { get; set; }
    }

    public class ClassifiedsPackage
    {
        public string id { get; set; }
    }

    public class Commission
    {
        public string name { get; set; }
        public string type { get; set; }
        public Fee fee { get; set; }
    }

    public class Fee
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class Quote
    {
        public string name { get; set; }
        public string type { get; set; }
        public Fee fee { get; set; }
        public string cycleDuration { get; set; }
        public ClassifiedsPackage classifiedsPackage { get; set; }
    }
}
