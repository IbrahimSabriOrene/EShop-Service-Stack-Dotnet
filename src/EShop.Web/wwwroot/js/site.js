// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToCart() {
    var productId = document.getElementById("productId").value;
    document.getElementById("add_cart_form").submit();
    document.getElementById("remove_from_cart").submit();


}

function getImagesFromWwwroot() {
    var image = document.getElementById("image");
    var imageSrc = image.getAttribute("src");
    var newSrc = "wwwroot/images/" + imageSrc;
    image.setAttribute("src", newSrc);
}