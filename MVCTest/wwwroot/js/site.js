$(document).ready(function () {
    GetList();

    $("#dialog").dialog({
        title: "Filter Employees",
        minWidth: 600,
        minHeight: 180,
        autoOpen: false,
        draggable: true,
        resizable: true
    });

    $("#btnFilter").click(function () {
        $("#dialog").dialog("open");
    });

    $("#btnFilterCancel").click(function () {
        DialogClosed();
    });

    $("#btnFilterOK").click(function () {
        GetList();
        DialogClosed();
    });
});

function GetList() {
    var searchValue = $("#inputSearchField").val();

    $.ajax({
        url: "../Home/RefreshList/",
        type: "GET",
        data: { "searchValue": searchValue },
        dataType: "json",
        success: function (data) {
            var markup = "";

            $("#tbodyMain").empty();

            $.each(data, function (key, value) {
                markup = markup + "<tr>";
                markup = markup + "<td class='align-middle'>" + value["employee"].employeeId + "</td>";
                markup = markup + "<td class='align-middle'>" + value["employee"].fullName + "</td>";
                markup = markup + "<td class='align-middle'><table><tbody>";
                $.each(value["totalHours"], function (innerKey, innerValue) {
                    markup = markup + "<tr>";
                    markup = markup + "<td>" + innerValue.monthName + " - " + innerValue.hours + "</td>";
                    markup = markup + "</tr>";
                });
                markup = markup + "</tbody></table></td>";
                markup = markup + "</tr>";
            });

            if (markup == "") {
                markup = markup + "<tr><td class='text-center align-middle' colspan='3'>No rows found.</td></tr>";
            }

            $("#tbodyMain").append(markup);
        },
        error: function (req, status, errorObj) {
            alert(errorObj);
        }
    });
}

function DialogClosed() {
    $("#inputSearchField").val("");
    $("#dialog").dialog("close");
}