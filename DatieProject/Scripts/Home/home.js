$(document).ready(function () {
    window.dt = $("#table").DataTable({
        "ajax": {
            "url": "Home/GetData",
            "type": "POST",
            "dataType": "json",
            "data": "data",
        },
        "columns": [
        { "data": "Username" },
        { "data": "RegDate" },
        {
            "data": function (data) {
                if (data.IsAdmin) {
                    return "Admin";
                } else {
                    return "User";
                }
            }
        },
        {
            "data": function (data) {
                if (data.IsActive) {
                    return "Active";
                } else {
                    return "Deactivate";
                }
            }
        },
            {
                "data": function (data, type, full, meta) {
                    if (data.IsActive) {
                        return ' <button id="btnEdit" class="btn btn-danger" onclick="Active(this, event)" data-status="Deactivate" data-id="' + data.Username + '" class="glyphicon glyphicon-edit">Deactivate</button>';
                    } else {
                        return ' <button id="btnEdit" class="btn btn-primary" onclick="Active(this, event)"  data-status="Active"  data-id="' + data.Username + '" class="glyphicon glyphicon-edit">Active</button>';
                    }
                  
                }
            }
        ]
    });

});


function Active(btn, event) {
    var id = $(btn).data('id');
    var status = $(btn).data('status');
    $.ajax({
        url: 'Home/ChangeStatus',
        type: 'POST',
        data: { id: id, status: status },
        success: function (data) {
            dt.ajax.reload(null, false);
        }
    });
}

