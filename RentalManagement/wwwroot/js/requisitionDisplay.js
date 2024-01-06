function getRequisitionDetails(requisitionId) {
    $.ajax({
        type: 'GET',
        url: '/api/RequisitionApi/getRequisitionDetails/' + requisitionId, 
        success: function (data) {
            displayRequisitionDetails(data);
        },
        error: function (error) {
            console.error('Error fetching requisition details:', error);
        }
    });
}

function displayRequisitionDetails(data) {
    // Update HTML elements with requisition details
    $('#requisitionId').text(data.RequisitionId);
    $('#requester').text(data.Tenant_FirstName + ' ' + data.Tenant_LastName);
    $('#requisitionType').text(data.Requisition_Type);
    $('#requestedDate').text(data.Requistition_CreatedAt);

    showReqPopUpModal();
}

function showReqPopUpModal() {
    var reqPM = document.getElementById('reqPopUpModal');
    var footer = document.querySelector('footer');

    reqPM.style.display = 'block';
    reqPM.style.height = '300px';
    footer.style.marginTop = '350px';
}

$('.reqActionButton').click(function () {
    var tenantId = $(this).data('req-id');
    // Fetch and display requisition details when the button is clicked
    getRequisitionDetails(tenantId);
});

$(document).ready(function () {

    $('.reqActionButton').click(function () {
        // var tenantId = $(this).data('req-id');
        var reqPM = document.getElementById('reqPopUpModal');
        var footer = document.querySelector('footer')

        reqPM.style.display = 'block';
        reqPM.style.height = '300px';
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


    // hide pop when other buttons (categories) are clicked
    $('#tenantButton').click(function ()) {
        $('#reqPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }
    $('#roomButton').click(function ()) {
        $('#reqPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }
    $('#reportsButton').click(function ()) {
        $('#reqPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }
    $('#feedbackButton').click(function ()) {
        $('#reqPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }
    $('#appButton').click(function ()) {
        $('#reqPopUpModal').hide();
        var footer = document.querySelector('footer');
        footer.style.marginTop = '0';
    }
    



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

// submodal
document.getElementById('numericInput').addEventListener('input', function (event) {
    // Get the input value
    let inputValue = event.target.value;

    // Remove non-numeric characters using a regular expression
    let numericValue = inputValue.replace(/\D/g, '');

    // Update the input value with only numeric characters
    event.target.value = numericValue;
});

function handleSelectChange(selectElement) {
    // Get the selected value
    var selectedValue = selectElement.value;

    // Enable or disable the numericInput based on the selected value
    var numericInput = document.getElementById('numericInput');
    numericInput.disabled = selectedValue === 'default';

    // Clear the numericInput value when no option is selected
    if (selectedValue === 'default') {
        numericInput.value = '';
    }
}

function handleNumericInputChange() {
    // Get the numericInput element
    var numericInput = document.getElementById('numericInput');

    // Get the selected value from the dropdown
    var selectElement = document.getElementById('item1DD');
    var selectedValue = selectElement.value;

    // Prevent input if no option is selected
    if (selectedValue === 'default') {
        numericInput.value = '';
    }
}
