$(document).ready(function () {
    // Function to fetch and populate suppliers
    function populateSuppliers() {
        $.ajax({
            url: '/Suppliers/GetSuppliers',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                // Clear existing table rows
                $('#supplierTableBody').empty();

                // Populate data into the table
                $.each(data, function (index, supplier) {
                    $('#supplierTableBody').append(
                        '<tr>' +
                        '<td>' + supplier.suppliersId + '</td>' +
                        '<td>' + supplier.suppliers_Name + '</td>' +
                        '<td>' + supplier.suppliers_Email + '</td>' +
                        '<td>' + supplier.suppliers_PhoneNumber + '</td>' +
                        '<td>' + supplier.suppliers_Address + '</td>' +
                        '<td><button class="editBtn" data-id="' + supplier.suppliersId + '">Edit</button>' + 
                        '<button class="deleteBtn" data-id="' + supplier.suppliersId + '">Delete</button></td>' +
                        '</tr>'
                    );
                });
                // Attach click event to the "Edit" buttons
                $('.editBtn').click(function () {
                    var supplierId = $(this).data('id');
                    openEditModal(supplierId);
                });

                $('.deleteBtn').click(function () {
                    var supplierId = $(this).data('id');
                    // Show confirmation dialog
                    var confirmDelete = confirm("Are you sure you want to delete this supplier?");
                    if (confirmDelete) {
                        deleteSupplier(supplierId);
                    }
                });
            },
            error: function (error) {
                console.error('Error fetching suppliers:', error);
            }
        });
    }
    // Function to open the edit modal and populate with supplier details
    function openEditModal(supplierId) {
        $.ajax({
            url: '/Suppliers/Details/' + supplierId,
            type: 'GET',
            dataType: 'json',
            success: function (supplier) {
                // Populate edit modal with supplier details
                $('#SupplierID').val(supplier.suppliersId);
                $('#SupplierNameInput').val(supplier.suppliers_Name);
                $('#SupplierEmailInput').val(supplier.suppliers_Email);
                $('#SupplierPhoneInput').val(supplier.suppliers_PhoneNumber);
                $('#SupplierAddressInput').val(supplier.suppliers_Address);

                // Show the edit modal
                $('#editModal').show();
            },
            error: function (error) {
                console.error('Error fetching supplier details:', error);
            }
        });
    }

    // Function to handle form submission
    $('#submitSupplier').click(async function () {
        var formData = {
            Suppliers_Name: $('#SupplierName').val(),
            Suppliers_Email: $('#SupplierEmail').val(),
            Suppliers_PhoneNumber: $('#SupplierPhone').val(),
            Suppliers_Address: $('#SupplierAddress').val(),
        };

        // Perform client-side validation
        var isValid = validateFormData(formData);
        if (!isValid) {
            return;
        }

        // Check if the name already exists in the database
        var nameExists = await checkNameExists(formData.Suppliers_Name.trim());
        if (nameExists) {
            $('#supplierNameError').text('Supplier name already exists in the database.');
            return;
        } else {
            // Clear any previous error message
            $('#supplierNameError').text('');
        }

        // Show confirmation dialog before inserting into the database
        var confirmInsert = confirm("Are you sure you want to insert this supplier into the database?");
        if (!confirmInsert) {
            return;
        }

        // Perform server-side validation using AJAX
        $.ajax({
            url: '/Suppliers/InsertSupplier',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                if (response.success) {
                    // Close the form and refresh the supplier table
                    $('#addSupplierForm').hide();
                    populateSuppliers();
                } else {
                    // Display server-side validation errors
                    displayValidationErrors(response.errors);
                }
            },
            error: function (error) {d
                console.error('Error inserting supplier:', error);
                showErrorDialog("Error inserting supplier. Please try again.");
            }
        });
    });

    // Function to display an error dialog
    function showErrorDialog(message) {
        alert(message);
    }

    // Function to validate form data
    async function validateFormData(formData) {
        var isValid = true;
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        var phoneRegex = /^09\d{9}$/;

        if (formData.Suppliers_Name.trim() === '') {
            $('#supplierNameError').text('Supplier Name is required.');
            isValid = false;
        } else {
            $('#supplierNameError').text('');
            if (!emailRegex.test(formData.Suppliers_Email.trim())) {
                $('#supplierEmailError').text('Enter a valid email address.');
                isValid = false;
            } else {
                $('#supplierEmailError').text('');
            }
            if (!phoneRegex.test(formData.Suppliers_PhoneNumber.trim())) {
                $('#supplierPhoneError').text('Enter a valid phone number (11 digits starting with 09).');
                isValid = false;
            } else {
                $('#supplierPhoneError').text('');
            }
            if (formData.Suppliers_Address.trim() === '') {
                $('#supplierAddressError').text('Supplier Address is required.');
                isValid = false;
            } else {
                $('#supplierAddressError').text('');
            }

            // Add similar validation for other fields

            return isValid;
        }
    }

    async function checkNameExists(name) {
        var exists = false;

        await $.ajax({
            url: '/Suppliers/CheckNameExists',
            type: 'POST',
            data: { name: name },
            async: true,
            success: function (response) {
                exists = response.exists;
            },
            error: function (error) {
                console.error('Error checking supplier name:', error);
            }
        });

        return exists;
    }

        // Function to display server-side validation errors
        function displayValidationErrors(errors) {
            // Display server-side validation errors in the specified <p> elements
            // The structure of 'errors' should match the server's response
            $('#supplierNameError').text(errors.Suppliers_Name || '');
            $('#supplierEmailError').text(errors.Suppliers_Email || '');
            $('#supplierPhoneError').text(errors.Suppliers_PhoneNumber || '');
            $('#supplierAddressError').text(errors.Suppliers_Address || '');
        }

    // Function to delete a supplier
    function deleteSupplier(supplierId) {
        $.ajax({
            url: '/Suppliers/DeleteSupplier/' + supplierId,
            type: 'POST',
            success: function (response) {
                if (response.success) {
                    // Refresh the supplier table after successful deletion
                    populateSuppliers();
                } else {
                    // Handle deletion failure, display error message if needed
                    console.error('Error deleting supplier:', response.error);
                }
            },
            error: function (error) {
                console.error('Error deleting supplier:', error);
            }
        });
    }

    // Call the populateSuppliers function when the page loads
    populateSuppliers();

    $('#addSupButton').click(function () {
        // Clear the form fields and validation errors
        $('#SupplierName, #SupplierEmail, #SupplierPhone, #SupplierAddress').val('');
        $('#supplierNameError, #supplierEmailError, #supplierPhoneError, #supplierAddressError').text('');

        // Show the popup form
        $('#addSupplierForm').show();
    });
    $('#closeForm').click(function () {
        $('#addSupplierForm').hide();
    });

});