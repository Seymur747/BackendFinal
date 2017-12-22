$(document).ready(function () {
    $("#menu").superfish({
        pathLevels: 1,
        delay: 0,
        animation: { opacity: 'show' },
        animationOut: { opacity: 'hide' },
        speed: 'fast',
        speedOut: 'fast',
        cssArrows: true,
        disableHI: false,
    });
    $("#menu").slicknav();

    $(window).on("scroll", function () {
        if ($(this).scrollTop() > $("header").height()) {
            $("header").addClass("fixed");
        } else {
            $("header").removeClass("fixed");
        }
    })
});