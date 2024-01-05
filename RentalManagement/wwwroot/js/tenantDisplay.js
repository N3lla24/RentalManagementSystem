$(document).ready(function () {


    $('.actionButton').click(function () {
        var tenantId = $(this).data('tenant-id');

        // Load data into the modal based on the TenantID
        loadModalData(tenantId);

        // Load payment history
        loadHistoryData('paymentHistory', 'getPaymentHistory', tenantId);

        // Load requisition history
        loadHistoryData('requisitionHistory', 'getRequisitionHistory', tenantId);

        // Show the modal
        $('#popUpModal').show();
    });

    $('.reqActionButton').click(function () {
        var tenantId = $(this).data('req-id');
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
        // Perform update logic here (send updated data to the server, etc.)

        // Hide the edit modal
        $('#editModal').hide();
    });
});

function loadModalData(tenantId) {
    // Assuming you have a function to fetch tenant data from the server based on the tenantId
    var tenantData = getTenantDataFromServer(tenantId);

    // Populate the modal with the retrieved data
    $('#tenantImage').attr('src', tenantData.imageUrl);
    $('#firstNameInput').val(tenantData.firstName);
    $('#middleNameInput').val(tenantData.middleName);
    $('#lastNameInput').val(tenantData.lastName);
    $('#phoneNumberInput').val(tenantData.phoneNumber);
}

function getTenantDataFromServer(tenantId) {
    // Mock data for demonstration purposes; replace this with actual server logic
    return {
        imageUrl: 'path/to/tenant/image.jpg',
        firstName: 'John',
        middleName: 'Doe',
        lastName: 'Smith',
        phoneNumber: '123-456-7890'
    };
}

function loadHistoryData(targetElementId, endpoint, tenantId) {
    $.ajax({
        type: 'GET',
        url: '/api/' + endpoint + '/' + tenantId, // Replace with your actual API endpoint
        success: function (data) {
            // Assuming the server returns an array of history items
            var historyItems = data;

            // Clear the existing content
            $('#' + targetElementId).empty();

            // Append new content based on the retrieved data
            for (var i = 0; i < historyItems.length; i++) {
                $('#' + targetElementId).append('<p>' + historyItems[i].description + '</p>');
                // Add more details as needed
            }
        },
        error: function (error) {
            console.error('Error loading history:', error);
        }
    });
}

//start
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