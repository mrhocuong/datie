$(document).ready(function() {
    window.dt = $("#table").DataTable({
        "ajax": {
            "url": "User/GetData",
            "type": "POST",
            "dataType": "json",
            "data": "data",
        },
        "columns": [
            { "data": "Username" },
            {
                "data": function(data) {
                    if (data.IsAdmin) {
                        return "<div class=\"five\">" +
                            "<div class=\"button-wrap button-active\" onclick=\"toggleChangeRole(this)\" data-id=\"" + data.Username + "\" data-status=\"User\">" +
                            "<div class=\"button-bg\">" +
                            "<div class=\"button-out\">Admin</div>" +
                            "<div class=\"button-in\">User</div>" +
                            "<div class=\"button-switch\"></div>" +
                            "</div>" +
                            "</div>" +
                            "</div>";
                    } else {
                        return "<div class=\"five\">" +
                            "<div class=\"button-wrap\" onclick=\"toggleChangeRole(this)\" data-id=\"" + data.Username + "\" data-status=\"Admin\">" +
                            "<div class=\"button-bg\">" +
                            "<div class=\"button-out\">Admin</div>" +
                            "<div class=\"button-in\">User</div>" +
                            "<div class=\"button-switch\"></div>" +
                            "</div>" +
                            "</div>" +
                            "</div>";
                    }
                }
            },
            {
                "data": function(data, type, full, meta) {
                    if (data.IsActive) {
                        return "<div class=\"five\">" +
                            "<div class=\"button-wrap-two button-active\" onclick=\"toggleStatus(this)\" data-id=\"" + data.Username + "\" data-status=\"Deactivated\">" +
                            "<div class=\"button-bg-two\">" +
                            "<div class=\"button-out-two\">On</div>" +
                            "<div class=\"button-in-two\">Off</div>" +
                            "<div class=\"button-switch-two\"></div>" +
                            "</div>" +
                            "</div>" +
                            "</div>";
                    } else {
                        return "<div class=\"five\">" +
                            "<div class=\"button-wrap-two\" onclick=\"toggleStatus(this)\" data-id=\"" + data.Username + "\" data-status=\"Active\">" +
                            "<div class=\"button-bg-two\">" +
                            "<div class=\"button-out-two\">On</div>" +
                            "<div class=\"button-in-two\">Off</div>" +
                            "<div class=\"button-switch-two\"></div>" +
                            "</div>" +
                            "</div>" +
                            "</div>";
                    }

                }
            },
            {
                "data": function(data) {
                    if (data.IsActive) {
                        return "Active";
                    } else {
                        return "Deactivate";
                    }
                }
            },
            { "data": "RegDate" }
        ]
    });
  //  $("#table_filter input").addClass("form-control");
  //  $("#table_length select").addClass("form-control");
});

function Active(btn, event) {
    var id = $(btn).data("id");
    var status = $(btn).data("status");
    $.ajax({
        url: "User/ChangeStatus",
        type: "POST",
        data: { id: id, status: status },
        beforeSend: function() {
            $.blockUI({ message: "<h1><img src=\"Content/loading.gif\" />Please wait...</h1>" });
        },
        success: function(data) {
            if (data.success == false) {
                bootbox.dialog({
                    message: "You do not have permission.",
                    title: "Message",
                    buttons: {
                        success: {
                            label: "Close",
                            className: "btn btn-primary"
                        }
                    }
                });
            }
            dt.ajax.reload(null, false);
        },
        complete: function() {
            $.unblockUI();
        }
    });
}

function toggleStatus(btn) {
    $(btn).toggleClass("button-active");
    Active(btn);
}

function ChangeRole(btn, event) {
    var id = $(btn).data("id");
    var status = $(btn).data("status");
    $.ajax({
        url: "User/ChangeRole",
        type: "POST",
        data: { id: id, status: status },
        beforeSend: function() {
            $.blockUI({ message: "<h1><img src=\"Content/loading.gif\" />Please wait...</h1>" });
        },
        success: function(data) {
            if (data.success == false) {
                bootbox.dialog({
                    message: "You do not have permission.",
                    title: "Message",
                    buttons: {
                        success: {
                            label: "Close",
                            className: "btn btn-primary"
                        }
                    }
                });
            }
            dt.ajax.reload(null, false);
        },
        complete: function() {
            $.unblockUI();
        }
    });
}

function toggleChangeRole(btn) {
    $(btn).toggleClass("button-active");
    ChangeRole(btn);
}