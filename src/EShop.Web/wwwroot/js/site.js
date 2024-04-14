// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToCart() {
    // Get the productId from the hidden input
    var productId = document.getElementById("productId").value;
    // Perform any additional checks or operations if needed
    // Submit the form as post
    
    document.getElementById("add_cart_form").submit();


}