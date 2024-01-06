function displayTenantDetails(data) {
    // Update HTML elements with tenant details
    $('#tenantId').text(data.TenantID);
    $('#tenantFirstName').text(data.Tenant_FirstName);
    $('#tenantLastName').text(data.data.Tenant_LastName);

    showTenantPopUpModal();
}

function showTenantPopUpModal() {
    var tenantPM = document.getElementById('tenantPopUpModal');
    var footer = document.querySelector('footer');

    tenantPM.style.display = 'block';
    tenantPM.style.height = '300px';
    footer.style.marginTop = '350px';
}

//double check with available event handlers in the tenantDisplay
$(document).ready(function () {

    $('.tenantActionButton').click(function () {
        var tenantPM = document.getElementById('tenantPopUpModal');
        var footer = document.querySelector('footer');

        tenantPM.style.display = 'block';
        tenantPM.style.height = '300px';
        footer.style.marginTop = '350px';
    });

    $('#reqApprove').click(function () {
        $('.reqConfirmPopUp').show();
    });

    $('.rcpCancel').click(function () {
        $('.reqConfirmPopUp').hide();
    });
    $('#reqReject').click(function () {
        $('.reqRejectPopUp').show();
    });
    $('.rrpCancel').click(function () {
        $('.reqRejectPopUp').hide();
    });
    $('.rrpProceed').click(function () {
        $('.reqRejectPopUp').hide();
        $('#reqPopUpModal').hide();
        var footer = document.querySelector('footer')
        footer.style.marginTop = '0';
    });
    $('#reqX').click(function () {
        $('#reqPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    });




    $('#editButton').click(function () {
        // Show the edit modal
        $('#editModal').show();
    });

    $('#closeButton').click(function () {
        // Close the modal
        $('#popUpModal').hide();
    });

    $('#discardButton').click(function () {
        // Hide the edit modal
        $('#editModal').hide();
    });

    $('#updateButton').click(function () {
        // Hide the edit modal
        $('#editModal').hide();
    });
});
