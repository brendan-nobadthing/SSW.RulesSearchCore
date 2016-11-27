
$(document)
    .ready(function() {
        console.log("ready");
        $("#btn-search").on("click", doSearch);
        $("form").on("submit", doSearch);
    });


var doSearch = function () {
    $.get("/search/search?query=" + encodeURI($("#search-query").val()))
        .done(function (response) {
            console.log(response);
            $("#search-results").html(response);
        })
        .fail(function (response) {
            console.log(response);
            $("#search-results").html(response.responseText);
        });

    return false;
}