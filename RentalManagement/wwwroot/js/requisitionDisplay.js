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
    $('#requester').text(data.tenant_FirstName + ' ' + data.Tenant_LastName);
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
