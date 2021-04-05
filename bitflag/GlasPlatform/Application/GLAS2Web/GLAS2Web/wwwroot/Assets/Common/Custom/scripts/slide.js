function initializeSlide() {
    $('[data-toggle="slide"]').click(function () {
        var time = 400;
        var target = $(this).data('target');
        var icon = $(this).data('slide-icon');

        if ($(target).is(':visible')) {
            $(target).slideUp(time);
            if (icon != null) $(icon).removeClass('fa-chevron-up').addClass('fa-chevron-down');
        } else {
            $(target).slideDown(time);
            if (icon != null) $(icon).removeClass('fa-chevron-down').addClass('fa-chevron-up');
        }
    });
}

$(document).ready(initializeSlide);