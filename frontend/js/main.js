document.addEventListener("DOMContentLoaded", function () {
    getVisitCount();
});

const functionApiUrl = "https://tarik-azure-site.azurewebsites.net/api/GetCounter?code=P3In89AETTBRBxvuzZTwWZh3MISGBXkF14Tr1iMy8YuqAzFuQFGT_w%3D%3D";
const localFunctionApiUrl = "http://localhost:7071/api/GetCounter";

function getVisitCount() {
    var count = 1;

    fetch(functionApiUrl).then(response => {
        return response.json();
    }).then(response => {
        console.log("Website called function API");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function (error) {
        document.getElementById("counter").innerText = count;
        console.log(error);
    });

    return count;
}