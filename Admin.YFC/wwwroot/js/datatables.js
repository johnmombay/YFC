$(document).ready(function () {
    $('#statements').DataTable({
        "ajax": "User/GetUsers",
        "columns": [
            { "data": "message" },
            { "data": "author" },
            {
                "render": function (data, type, row) {
                    return "<a href='Statements/Edit/" + row.statementId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Statements/Remove/" + row.statementId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});