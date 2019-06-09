// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GetDetails(event) {
    event.preventDefault();
    if (event.target.classList.length == 0) {
        event.target.parentNode.classList.add('moreInfoFetched');

        Array.from(event.target.parentNode.querySelectorAll("ul li")).forEach(element =>
        {
            var request = new Request("/api/member/" + element.id, { method: 'GET' });
            fetch(request)
                .then(function (resp) {
                    return resp.json();
            })
            .catch(function (resp) { console.log(resp) })
            .then(function (jsonResp) {
                element.querySelector(".fullTitle").textContent = jsonResp.fullTitle;
                element.querySelector(".memberFrom").textContent = jsonResp.memberFrom;
                element.querySelector(".party").textContent = jsonResp.party.name;
            })
    });
}
}
