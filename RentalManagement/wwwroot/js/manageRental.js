$(document).ready(function () {
    // Initially show the tenantDisplay and hide others
    $('.tenantDisplay').show();
    $('.reqDisplay, .roomDisplay, .reportsDisplay, .invoiceDisplay, .appDisplay').hide();

    $('.displayButton').click(function () {
        // Hide all displays
        $('.tenantDisplay, .reqDisplay, .roomDisplay, .reportsDisplay, .invoiceDisplay, .appDisplay').hide();

        $('#reqPopUpModal').hide();
        var footer = document.querySelector('footer')
        footer.style.marginTop = '0';
        // Show the corresponding display based on data-target attribute
        var target = $(this).data('target');
        $('.' + target).show();
    });

});