using System;

namespace SSW.RulesSearchCore.Domain
{
    public class Rule
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public PublishingPageLayout PublishingPageLayout { get; set; }

        public string PublishingPageContent { get; set; }

        public string RuleContentTop { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string RulesKeyWords { get; set; }

        public RuleCategoriesMetadata[] RuleCategoriesMetadata { get; set; }
    }


    public class PublishingPageLayout
    {
        public string Description { get; set; }
        public string Url { get; set; }
    }


    public class RuleCategoriesMetadata
    {
        public string Label { get; set; }
        public string TermGuid { get; set; }
        public int WssId { get; set; }
    }
}