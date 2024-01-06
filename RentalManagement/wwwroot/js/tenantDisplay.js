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

$(document).ready(function () {

    $('.tenantActionButton').click(function () {
        var tenantPM = document.getElementById('tenantPopUpModal');
        var footer = document.querySelector('footer');

        tenantPM.style.display = 'block';
        tenantPM.style.height = '300px';
        footer.style.marginTop = '350px';
    });

    // x mark to close pop up
    $('#tenantX').click(function () {
        $('#tenantPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    });

    // hide pop when other buttons (categories) are clicked
    $('#reqButton').click(function ()) {
        $('#tenantPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }
    $('#roomButton').click(function ()) {
        $('#tenantPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }
    $('#reportsButton').click(function ()) {
        $('#tenantPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }
    $('#feedbackButton').click(function ()) {
        $('#tenantPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }
    $('#appButton').click(function ()) {
        $('#tenantPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }





    $('#editButton').click(function () {
        $('#tenantRoomNumberSpan').hide(); // Hide the span
        $('#unitNumberInput').show(); // Show the input field
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
