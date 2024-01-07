$(document).ready(function () {
    $('#Requisition_Type').change(function () {
        var selectedType = $(this).val();
        if (selectedType === 'REQUEST_ITEM') {
            $('#itemSection').show();
            $('#serviceSection').hide();
        } else if (selectedType === 'REQUEST_SERVICE') {
            $('#itemSection').hide();
            $('#serviceSection').show();
        } else {
            $('#itemSection').hide();
            $('#serviceSection').hide();
        }
    });
    var itemCount = 1;
    $('.addItemButton').click(function () {
        var newItemField = '<div class="itemField">' +
            '<label for="Req_Item_Name_' + itemCount + '">Item Name:</label>' +
            '<input type="text" id="Req_Item_Name_' + itemCount + '" name="RequisitionItems[' + itemCount + '].Req_Item_Name" />' +

            '<label for="Req_Item_Quantity_' + itemCount + '">Item Quantity:</label>' +
            '<input type="text" id="Req_Item_Quantity_' + itemCount + '" name="RequisitionItems[' + itemCount + '].Req_Item_Quantity" />' +

            '<label for="Req_Item_Units_' + itemCount + '">Item Unit/s:</label>' +
            '<input type="text" id="Req_Item_Units_' + itemCount + '" name="RequisitionItems[' + itemCount + '].Req_Item_Units" />' +


            '<input type="hidden" name="RequisitionItems[' + itemCount + '].RequisitionId" value="' + $('#RequisitionId').val() + '" />' +
            '<button type="button" class="removeItemButton" data-field-id="' + itemCount + '">Remove Item</button>' +
            '</div>';

        $('#itemSection').append(newItemField);
        itemCount++;
    });

    var serviceCount = 1;
    $('.addServiceButton').click(function () {
        var newServiceField = '<div class="serviceField">' +
            '<label for="Req_Serv_Name_' + serviceCount + '">Service Name:</label>' +
            '<input type="text" id="Req_Serv_Name_' + serviceCount + '" name="RequisitionServices[' + serviceCount + '].Req_Serv_Name" />' +

            '<input type="hidden" name="RequisitionServices[' + serviceCount + '].RequisitionId" value="' + $('#RequisitionId').val() + '" />' +
            '<button type="button" class="removeServiceButton" data-field-id="' + serviceCount + '">Remove Service</button>' +
            '</div>';

        $('#serviceSection').append(newServiceField);
        serviceCount++;
    });
    $(document).on('click', '.removeItemButton', function () {
        var fieldId = $(this).data('field-id');
        $('#itemField_' + fieldId).remove();
    });

    $(document).on('click', '.removeServiceButton', function () {
        var fieldId = $(this).data('field-id');
        $('#serviceField_' + fieldId).remove();
    });

});