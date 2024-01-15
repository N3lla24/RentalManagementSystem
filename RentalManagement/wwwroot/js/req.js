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

    
    function handleItemChange(selectElement) {
        var selectedOption = selectElement.find('option:selected');
        var id = selectedOption.data('id');
        var name = selectedOption.data('iname');
        var quantity = selectedOption.data('quantity');
        var unit = selectedOption.data('unit');

        var row = selectElement.closest('.item-row');
        row.find('.item-name').val(name);
        row.find('.item-quantity').val(quantity);
        row.find('.item-units').val(unit);
        row.find('.inventory-id').val(id);
    }

    $('.item-name').each(function () {
        handleItemChange($(this));
    });

    $(document).on('change', '.item-name', function () {
        handleItemChange($(this));
    });

    var itemCount = 1;

    $(".addanotheritem").click(function () {
        var newRow = $(".item-row:first").clone();
        newRow.find('.item-name').attr('name', 'RequisitionItem[' + itemCount + '].Req_Item_Name');
        newRow.find('.item-quantity').attr('name', 'RequisitionItem[' + itemCount + '].Req_Item_Quantity');
        newRow.find('.item-units').attr('name', 'RequisitionItem[' + itemCount + '].Req_Item_Units');
        newRow.find('.inventory-id').attr('name', 'RequisitionItem[' + itemCount + '].InventoryId');

        newRow.find('.addanotheritem').hide();
        newRow.find('.removeitem').show();

        newRow.find('.item-name').val('');
        newRow.find('.item-quantity').val('');
        newRow.find('.item-units').val('');
        newRow.find('.inventory-id').val('');

        $(".itemTable tbody").append(newRow.show());
        itemCount++;
    });

    $(".itemTable").on("click", ".removeitem", function () {
        $(this).closest(".item-row").remove();
    });

    var serviceCount = 1;
    $('.addServiceButton').click(function () {
        var newServiceField = '<div class="serviceField">' +
            '<label for="Req_Serv_Name_' + serviceCount + '">Service Name:</label>' +
            '<input type="text" id="Req_Serv_Name_' + serviceCount + '" name="RequisitionServices[' + serviceCount + '].Req_Serv_Name" />' +

            '<input type="hidden" name="RequisitionServices[' + serviceCount + '].RequisitionId" value="' + $('#RequisitionId').val() + '" />' +
            '<a href="javascript:void(0);" class="removeServiceLink" style="color: red;" data-field-id="' + serviceCount + '">Remove Service</a>' +
            '</div>';

        $('#serviceSection').append(newServiceField);
        serviceCount++;
    });

    $(document).on('click', '.removeServiceLink', function () {
        var fieldId = $(this).data('field-id');
        $('#Req_Serv_Name_' + fieldId).closest('.serviceField').remove();
    });

});
