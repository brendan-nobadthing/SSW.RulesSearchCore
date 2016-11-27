using System.Collections.Generic;
using Nest;
using SSW.RulesSearchCore.Domain;
using System.Linq;

namespace SSW.RulesSearchCore.Elastic
{
    public class ElasticTextSearch : ITextSearch
    {

        private readonly ElasticClient _elasticClient;

        public ElasticTextSearch(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public IEnumerable<RuleSearchResult> Search(string searchText)
        {
            var results = _elasticClient.Search<Rule>(s => s
                    .From(0)
                    .Size(20)

                    .Query(q => q.Match(m => m.Field(f => f.PublishingPageContent).Query(searchText)))

                    .Highlight(h => h
                            .PreTags("<b style='color:red'>")
                            .PostTags("</b>")
                            .Fields(fs => fs
                                    .Field(f => f.PublishingPageContent)
                                    .FragmentSize(50)
                                    .NumberOfFragments(4)
                                    .HighlightQuery(q => q.Match(m => m.Field(f => f.PublishingPageContent).Query(searchText)))
                            )

                    )
            );

            return results.Hits.Select(hit => new RuleSearchResult()
            {
                Rule = hit.Source,
                Score = hit.Score.GetValueOrDefault(),
                Context = string.Join("...", hit.Highlights.SelectMany(h => h.Value.Highlights))
            });

        }
    }
}