$(document).ready(function () {
    // Initially show the tenantDisplay and hide others
    $('.tenantDisplay').show();
    $('.reqDisplay, .roomDisplay, .reportsDisplay, .feedDisplay, .appDisplay').hide();

    $('.displayButton').click(function () {
        // Hide all displays
        $('.tenantDisplay, .reqDisplay, .roomDisplay, .reportsDisplay, .feedDisplay, .appDisplay').hide();

        // Show the corresponding display based on data-target attribute
        var target = $(this).data('target');
        $('.' + target).show();
    });

});