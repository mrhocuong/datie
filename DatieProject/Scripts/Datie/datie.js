$(document).ready(function() {
    $("#example").DataTable({
        "ajax": {
            "url": "Datie/GetData",
            "type": "POST",
            "dataType": "json",
            "data": "data",
        },
        "columns": [
        { "data": "ShopId" },
        { "data": "ShopName" },
        { "data": "ShopAddress" },
        { "data": "ShopPhone" },
        { "data": "ShopDescription" },
        { "data": "ShopTimeMid" },
        { "data": "ShopPriceMid" },
        { "data": "ShopRate" },
        { "data": "ShopIsDeleted" },
            {
                "data": function(data, type, full, meta) {
                    return ' <a id="btnAdd" onclick="AddShop()" data-toggle="modal" data-target="#dialog" class="glyphicon glyphicon-plus-sign"></a>' +
                       ' <a id="btnRemove" class="glyphicon glyphicon-remove-sign"></a>' +
                        ' <a id="btnEdit" class="glyphicon glyphicon-edit"></a>';
                }
            }
        ],
        "columnDefs": [{ "targets": 9, "orderable": false }]
    });
});

function AddShop(btn) {
    $.ajax({
        url: 'Datie/AddShop',
        type: 'GET',
        success: function (data) {
            $('#dialog').html(data);
            $('#dialog').modal('show');
        }
    });
}