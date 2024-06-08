const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("expand");
});

$(document).ready(function () {
    $('.has-dropdown').on('click', function () {
        console.log('Dropdown clicked!');
        $(this).find('.sidebar-dropdown').slideToggle();
    });
});

