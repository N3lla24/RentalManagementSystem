document.addEventListener("DOMContentLoaded", function () {
    showRFList();
});

document.addEventListener('click', function (event) {
    var isModalContent = document.getElementById('rfDetailsModal').contains(event.target);
    var isViewDetailsButton = event.target.classList.contains('view-details-button');

    if (!isModalContent && !isViewDetailsButton) {
        closeRFDetails();
    }
});

function hideModalsExcept(selectedModalId) {
    // Get an array of all modal IDs
    var modalIds = ['rfList', 'tenantDetails', 'roomDetails', 'analyticsDashboard', 'feedbackTable', 'tenantApplications'];

    // Loop through the modal IDs
    for (var i = 0; i < modalIds.length; i++) {
        var modalId = modalIds[i];

        // Check if the current modal is the selected one
        if (modalId !== selectedModalId) {
            // Hide the modal
            var modal = document.getElementById(modalId);
            modal.style.display = 'none';
        }
    }
}


var sampleRFData = [
    { id: 1, firstName: 'Ronel', lastName: 'Delig' },
    { id: 2, firstName: 'Omar', lastName: 'Pila' },
    { id: 3, firstName: 'Jayla', lastName: 'Monares' },
    { id: 4, firstName: 'Yancy', lastName: 'Salas' },
    { id: 1, firstName: 'Ronel', lastName: 'Delig' },
    { id: 2, firstName: 'Omar', lastName: 'Pila' },
    { id: 3, firstName: 'Jayla', lastName: 'Monares' },
    { id: 4, firstName: 'Yancy', lastName: 'Salas' },
    { id: 1, firstName: 'Ronel', lastName: 'Delig' },
    { id: 2, firstName: 'Omar', lastName: 'Pila' },
    { id: 3, firstName: 'Jayla', lastName: 'Monares' },
    { id: 4, firstName: 'Yancy', lastName: 'Salas' },
    { id: 1, firstName: 'Ronel', lastName: 'Delig' },
    { id: 2, firstName: 'Omar', lastName: 'Pila' },
    { id: 3, firstName: 'Jayla', lastName: 'Monares' },
    { id: 4, firstName: 'Yancy', lastName: 'Salas' }
];

populaterfTable(sampleRFData);

function showRFList() {
    hideModalsExcept('rfList');
    document.getElementById('rfList').style.display = 'block';
}

function populaterfTable(rfData) {
    var tableBody = document.getElementById('rfTable').getElementsByTagName('tbody')[0];
    tableBody.innerHTML = '';

    for (var i = 0; i < rfData.length; i++) {
        var row = tableBody.insertRow(i);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = row.insertCell(3);

        cell1.textContent = rfData[i].id;
        cell2.textContent = rfData[i].firstName;
        cell3.textContent = rfData[i].lastName;

        // button creatin
        var viewDetailsButton = document.createElement('button');
        viewDetailsButton.textContent = 'View Details';
        viewDetailsButton.classList.add('view-details-button');

        // get correct info base sa id
        viewDetailsButton.onclick = (function (rf) {
            return function () {
                showRFDetailsModal(rf);
            };
        })(rfData[i]);

        cell4.appendChild(viewDetailsButton);

    }
}


function showRFDetailsModal(rf) {
    var rfDetailsModal = document.getElementById('rfDetailsModal');

    // Clear existing content
    while (rfDetailsModal.firstChild) {
        rfDetailsModal.removeChild(rfDetailsModal.firstChild);
    }

    var firstCol = document.createElement('div');
    firstCol.className = 'firstCol';

    var imageParagraph = document.createElement('p');
    imageParagraph.textContent = 'Image is here';

    firstCol.appendChild(imageParagraph);

    rfDetailsModal.appendChild(firstCol);

    var detailsParagraph = document.createElement('p');
    var detailsParagraph2 = document.createElement('p');
    var detailsParagraph3 = document.createElement('p');
    detailsParagraph.textContent = 'Request ID: ' + rf.id;
    detailsParagraph2.textContent = 'Requested Item or Service: ' + rf.firstName;
    detailsParagraph3.textContent = 'Comments: ' + rf.lastName;

    rfDetailsModal.appendChild(detailsParagraph);
    rfDetailsModal.appendChild(detailsParagraph2);
    rfDetailsModal.appendChild(detailsParagraph3);

    var approveButton = document.createElement('button');
    var rejectButton = document.createElement('button');
    approveButton.textContent = 'Approve';
    rejectButton.textContent = 'Reject';

    approveButton.onclick = function () {
        closeRFDetails();
    };
    rejectButton.onclick = function () {
        closeRFDetails();
    };

    rfDetailsModal.appendChild(approveButton);
    rfDetailsModal.appendChild(rejectButton);

    var overlay = document.createElement('div');
    overlay.className = 'overlay';
    document.body.appendChild(overlay);

    rfDetailsModal.style.display = 'block';

    document.body.style.overflow = 'hidden';

    closeButton.onclick = function () {
        closeRFDetails();
    };
}

function closeRFDetails() {
    var rfDetailsModal = document.getElementById('rfDetailsModal');
    rfDetailsModal.style.display = 'none';

    var overlay = document.querySelector('.overlay');
    if (overlay) {
        overlay.parentNode.removeChild(overlay);
    }

    document.body.style.overflow = 'auto';
}

