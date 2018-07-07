$(document).ready(function () {
    $('.sidbar-toggler').on('click', function () {
        $('.sidebar-body').animate({
            height: 'toggle'
        });
    });
});