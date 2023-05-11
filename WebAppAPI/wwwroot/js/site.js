// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var div1 = document.getElementById("div1");
var div2 = document.getElementById("div2");


function showDiv2() {
    document.getElementById("div1").addEventListener("click", function (event) {
        event.preventDefault();

        var amount = document.getElementById("amount").value;
        var price = document.getElementById("price").value;
        var totalPrice = document.getElementById("totalPrice");
        var count = document.getElementById("count");

        var total = amount * price;


        div1.style.display = "none";
        div2.style.display = "block";

        count.textContent = amount;
        totalPrice.textContent = total;

    });
}
