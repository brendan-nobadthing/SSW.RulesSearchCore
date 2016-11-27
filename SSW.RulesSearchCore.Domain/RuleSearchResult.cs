namespace SSW.RulesSearchCore.Domain
{
    public class RuleSearchResult
    {
        public Rule Rule { get; set; }

        public double Score { get; set; }

        public string Context { get; set; }
    }
}