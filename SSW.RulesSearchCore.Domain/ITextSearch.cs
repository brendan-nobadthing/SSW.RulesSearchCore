using System.Collections.Generic;

namespace SSW.RulesSearchCore.Domain
{
    public interface ITextSearch
    {
        IEnumerable<RuleSearchResult> Search(string searchText);
    }
}