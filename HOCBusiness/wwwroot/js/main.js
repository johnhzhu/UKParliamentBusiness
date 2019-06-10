// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GetDetails(event) {
    event.preventDefault();
    if (event.target.classList.length == 0) {
        event.target.parentNode.classList.add('moreInfoFetched');

        Array.from(event.target.parentNode.querySelectorAll("ul li")).forEach(e =>
        {
            var request = new Request("/api/member/" + e.id, { method: 'GET' });
            fetch(request)
                .then(function (resp) {
                    return resp.json();
            })
            .catch(function (resp) { console.log(resp) })
            .then(function (jsonResp) {
                e.querySelector(".fullTitle").textContent = jsonResp.fullTitle;
                e.querySelector(".memberFrom").textContent = jsonResp.memberFrom;
                e.querySelector(".party").textContent = jsonResp.party.name;
            })
    });
}
}
