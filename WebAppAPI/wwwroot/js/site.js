// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showDiv2() {
    var style = document.getElementById("div1").style;
    document.getElementById("div1").addEventListener("click", function (event) {
        event.preventDefault();
        style.display = "none";
        document.getElementById("div2").style.display = "block";
    });
}
