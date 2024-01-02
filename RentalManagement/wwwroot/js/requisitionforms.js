document.addEventListener("DOMContentLoaded", function () {
    showRFList();
});

document.addEventListener('click', function (event) {
    var isModalContent = document.getElementById('reqFormsDetailsModal').contains(event.target);
    var isViewDetailsButton = event.target.classList.contains('view-details-button');

    if (!isModalContent && !isViewDetailsButton) {
        closeRFDetails();
    }
});



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

populateRFTable(sampleRFData);

function showRFList() {
    hideModalsExcept('RFList');
    document.getElementById('RFList').style.display = 'block';
}

function populateRFTable(RFData) {
    var tableBody = document.getElementById('rfTable').getElementsByTagName('tbody')[0];
    tableBody.innerHTML = '';

    for (var i = 0; i < RFData.length; i++) {
        var row = tableBody.insertRow(i);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = row.insertCell(3);

        cell1.textContent = RFData[i].id;
        cell2.textContent = RFData[i].firstName;
        cell3.textContent = RFData[i].lastName;

        // button creatin
        var viewDetailsButton = document.createElement('button');
        viewDetailsButton.textContent = 'View Details';
        viewDetailsButton.classList.add('view-details-button');

        // get correct info base sa id
        viewDetailsButton.onclick = (function (rf) {
            return function () {
                showRFDetailsModal(rf);
            };
        })(RFData[i]);


        cell4.appendChild(viewDetailsButton);

    }
}


function showRFDetailsModal(rf) {
    var reqFormsDetailsModal = document.getElementById('reqFormsDetailsModal');

    // Clear existing content
    while (reqFormsDetailsModal.firstChild) {
        reqFormsDetailsModal.removeChild(reqFormsDetailsModal.firstChild);
    }

    var firstCol = document.createElement('div');
    firstCol.className = 'firstCol';

    var imageParagraph = document.createElement('p');
    imageParagraph.textContent = 'Image is here';

    firstCol.appendChild(imageParagraph);

    reqFormsDetailsModal.appendChild(firstCol);

    var detailsParagraph = document.createElement('p');
    var detailsParagraph2 = document.createElement('p');
    var detailsParagraph3 = document.createElement('p');
    detailsParagraph.textContent = 'Tenant ID: ' + rf.id;
    detailsParagraph2.textContent = 'First Name: ' + rf.firstName;
    detailsParagraph3.textContent = 'Last Name: ' + rf.lastName;

    reqFormsDetailsModal.appendChild(detailsParagraph);
    reqFormsDetailsModal.appendChild(detailsParagraph2);
    reqFormsDetailsModal.appendChild(detailsParagraph3);

    var closeButton = document.createElement('button');
    closeButton.textContent = 'Close';

    closeButton.onclick = function () {
        closeRFDetails();
    };

    reqFormsDetailsModal.appendChild(closeButton);

    var overlay = document.createElement('div');
    overlay.className = 'overlay';
    document.body.appendChild(overlay);

    reqFormsDetailsModal.style.display = 'block';

    document.body.style.overflow = 'hidden';

    closeButton.onclick = function () {
        closeRFDetails();
    };
}

function closeRFDetails() {
    var reqFormsDetailsModal = document.getElementById('reqFormsDetailsModal');
    reqFormsDetailsModal.style.display = 'none';

    var overlay = document.querySelector('.overlay');
    if (overlay) {
        overlay.parentNode.removeChild(overlay);
    }

    document.body.style.overflow = 'auto';
}





