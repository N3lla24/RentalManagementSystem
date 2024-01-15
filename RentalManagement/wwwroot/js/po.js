$(document).ready(function () {
    $('#Purchase_Type').change(function () {
        var selectedType = $(this).val();
        if (selectedType === 'PURCHASE_ITEM') {
            $('#poiFields').show();
            $('#posFields').hide();
        } else if (selectedType === 'PURCHASE_SERVICE') {
            $('#poiFields').hide();
            $('#posFields').show();
        } else {
            $('#poiFields').hide();
            $('#posFields').hide();
        }
    });

    $(".addanotheritem").click(function () {
        var newRow = $(".item-row:first").clone();
        newRow.find('.item-name').attr('name', 'purchaseItems[' + itemCount + '].PurchaseItem_Name');
        newRow.find('.item-quantity').attr('name', 'purchaseItems[' + itemCount + '].PurchaseItem_Quantity');
        newRow.find('.item-units').attr('name', 'purchaseItems[' + itemCount + '].PurchaseItem_Unit');

        newRow.find('.addanotheritem').hide();
        newRow.find('.removeitem').show();

        newRow.find('.item-name').val('');
        newRow.find('.item-quantity').val('');
        newRow.find('.item-units').val('');

        $(".itemTable tbody").append(newRow.show());
        itemCount++;
    });

    $(".itemTable").on("click", ".removeitem", function () {
        $(this).closest(".item-row").remove();
    });

    var serviceCount = 1;
    $('.addPurchaseService').click(function () {
        var newServiceField = '<div class="serviceField">' +
            '<label for="PurchaseServ_Name' + serviceCount + '">Service Name:</label>' +
            '<input type="text" id="PurchaseServ_Name' + serviceCount + '" name="purchaseServices[' + serviceCount + '].PurchaseServ_Name" />' +

            '<input type="hidden" name="purchaseServices[' + serviceCount + '].PurchaseOrderId" value="' + $('#PurchaseOrderId').val() + '" />' +
            '<button type="button" class="removeServiceButton" data-field-id="' + serviceCount + '">Remove Service</button>' +
            '</div>';

        $('#serviceSection').append(newServiceField);
        serviceCount++;
    });
    $(document).on('click', '.removeServiceButton', function () {
        var fieldId = $(this).data('field-id');
        $('#PurchaseServ_Name' + fieldId).closest('.serviceField').remove();
    });
