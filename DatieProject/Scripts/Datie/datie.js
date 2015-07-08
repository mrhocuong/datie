$(document).ready(function () {
    window.dt = $("#example").DataTable({
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
        {
            "data": function (data) {
                if (data.ShopIsDeleted) {
                    return "Deleted";
                } else {
                    return "";
                }
            }
        },
            {
                "data": function (data, type, full, meta) {
                    return ' <button id="btnEdit" class="btn btn-primary" onclick="EditShop(this, event)" data-id="' + data.ShopId + '" class="glyphicon glyphicon-edit">Edit</button>';
                }
            }
        ],
        "columnDefs": [{ "targets": 9, "orderable": false }]
    });

});

function EditShop(btn, event) {
    var id = $(btn).data('id');
    $('#dialog').empty();
    $.ajax({
        url: 'Datie/EditShop',
        type: 'GET',
        data: { id: id },
        beforeSend: function () {
            $.blockUI({ message: '<h1><img src="Content/loading.gif" />Please wait...</h1>' });
        },
        success: function (data) {
            $('#dialog').html(data);
            $('#EditModal').modal();
            $(".numeric").numeric();
        },
        complete: function () {
            $.unblockUI();
        }
    });
}

function Edit(btn, event) {
    var model = $("#editForm").serialize();
    var str1 = $("#ShopIsDeleted").map(function () { return this.id + "=" + this.checked; }).get().join("&");
    if (str1 != "" && model != "") model += "&" + str1;
    else model += str1;
    $.ajax({
        url: 'Datie/EditShop',
        type: 'POST',
        data: model,
        success: function (data) {
            if (data.success) {
                $("#EditModal").modal("hide");
                bootbox.dialog({
                    message: "Edit data success.",
                    title: "Message",
                    buttons: {
                        success: {
                            label: "Close",
                            className: "btn btn-primary"
                        }
                    }
                });
                dt.ajax.reload(null, false);
            } else {
                bootbox.dialog({
                    message: "Edit data unsuccess. Try Again!",
                    buttons: {
                        success: {
                            label: "Close",
                            className: "btn btn-primary"
                        }
                    }
                });
            }
        }
    });
}

function AddShop(btn, event) {
    $('#dialog').empty();
    $.ajax({
        url: 'Datie/AddShop',
        type: 'GET',
        beforeSend: function () {
            $.blockUI({ message: '<h1><img src="Content/loading.gif" />Please wait...</h1>' });
        },
        success: function (data) {
            $('#dialog').html(data);
            $('#AddModal').modal();
            $(".numeric").numeric();
        },
        complete: function () {
            $.unblockUI();
        }
    });
}

function Add(btn, event) {
    var model = $("#addForm").serialize();
    $.ajax({
        url: 'Datie/Add',
        type: 'POST',
        data: model,
        success: function (data) {
            if (data.success) {
                $("#AddModal").modal("hide");
                bootbox.dialog({
                    message: "Create new shop success.",
                    title: "Message",
                    buttons: {
                        success: {
                            label: "Close",
                            className: "btn btn-primary"
                        }
                    }
                });
                dt.ajax.reload(null, false);
            } else {
                bootbox.dialog({
                    message: "Create new shop unsuccess. Try Again!",
                    buttons: {
                        success: {
                            label: "Close",
                            className: "btn btn-primary"
                        }
                    }
                });
            }
        }
    });
}
