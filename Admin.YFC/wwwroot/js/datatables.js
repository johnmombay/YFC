$(document).ready(function () {
    $('#statements').DataTable({
        "ajax": "Statements/GetStatements",
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

$(document).ready(function () {
    $('#inspirations').DataTable({
        "ajax": "Inspirations/GetInspirations",
        "columns": [
            { "data": "title" },
            { "data": "message" },
            { "data": "author" },
            {
                "render": function (data, type, row) {
                    return "<a href='Inspirations/Edit/" + row.inspirationId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Inspirations/Remove/" + row.inspirationId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#events').DataTable({
        "ajax": "Events/GetEvents",
        "columns": [
            { "data": "title" },
            { "data": "description" },
            { "data": "eventDate" },
            {
                "render": function (data, type, row) {
                    return "<a href='Events/Edit/" + row.eventId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Events/Remove/" + row.eventId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#headlines').DataTable({
        "ajax": "Headlines/GetHeadlines",
        "columns": [
            { "data": "title" },
            { "data": "subtitle" },
            { "data": "description" },
            { "data": "enable" },
            {
                "render": function (data, type, row) {
                    return "<a href='Headlines/Edit/" + row.headlineId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Headlines/Remove/" + row.headlineId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#teachings').DataTable({
        "ajax": "Teachings/GetTeachings",
        "columns": [
            { "data": "title" },
            { "data": "speaker" },
            { "data": "teachingDate" },
            {
                "render": function (data, type, row) {
                    return "<a href='Teachings/Edit/" + row.teachingId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Teachings/Remove/" + row.teachingId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#users').DataTable({
        "ajax": "Users/GetUsers",
        "columns": [
            { "data": "firstname" },
            { "data": "lastname" },
            { "data": "email" },
            {
                "render": function (data, type, row) {
                    return "<a href='Users/Edit/" + row.id + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Users/Remove/" + row.id + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});