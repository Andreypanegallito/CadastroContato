// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let btnCloseAlert = document.getElementsByClassName("close-alert");

for (let x = 0; x < btnCloseAlert.length; x++) {
    btnCloseAlert[x].addEventListener("click", function () {
        btnCloseAlert[x].parentElement.style.display = "none";
    })
}