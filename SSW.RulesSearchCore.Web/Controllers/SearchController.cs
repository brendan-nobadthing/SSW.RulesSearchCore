using Microsoft.AspNetCore.Mvc;
using SSW.RulesSearchCore.Domain;

namespace SSW.RulesSearchCore.Web.Controllers
{

    public class SearchController : Controller
    {

        private readonly ITextSearch _textSearch;

        public SearchController(ITextSearch textSearch)
        {
            _textSearch = textSearch;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string query)
        {
            var searchResults = _textSearch.Search(query);
            return PartialView("_SearchResults", searchResults);
        }
    }

}