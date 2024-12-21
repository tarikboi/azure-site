document.addEventListener("DOMContentLoaded", function () {
    getVisitCount();
});

const functionApi = "http://localhost:7071/api/GetCounter";

function getVisitCount() {
    var count = 1;

    fetch(functionApi).then(response => {
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