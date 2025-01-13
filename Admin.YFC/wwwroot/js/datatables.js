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
            { "data": "role" },
            {
                "render": function (data, type, row) {
                    return "<a href='Users/Edit/" + row.id + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Users/Remove/" + row.id + "'; class='btn btn-danger btn-sm' > Delete</a ><a href = 'Users/UpdateRole/" + row.id + "'; class='btn btn-secondary btn-sm' > Update Role</a ><a href = 'Users/ResetPassword/" + row.id + "'; class='btn btn-secondary btn-sm' > Reset Password</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#communities').DataTable({
        "ajax": "Communities/GetCommunities",
        "columns": [
            { "data": "name" },
            { "data": "enabled" },
            {
                "render": function (data, type, row) {
                    return "<a href='Communities/Edit/" + row.communityId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Communities/Remove/" + row.communityId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#ministries').DataTable({
        "ajax": "Ministries/GetMinistries",
        "columns": [
            { "data": "name" },
            { "data": "enabled" },
            {
                "render": function (data, type, row) {
                    return "<a href='Ministries/Edit/" + row.ministryId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Ministries/Remove/" + row.ministryId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#contents').DataTable({
        "ajax": "Contents/GetContents",
        "columns": [
            { "data": "sectionId" },
            {
                "render": function (data, type, row) {
                    return "<a href='Contents/Edit/" + row.contentId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Contents/Remove/" + row.contentId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#churches').DataTable({
        "ajax": "Churches/GetChurches",
        "columns": [
            { "data": "title" },
            { "data": "description" },
            { "data": "url" },
            {
                "render": function (data, type, row) {
                    return "<a href='Churches/Edit/" + row.churchId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Churches/Remove/" + row.churchId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#pastors').DataTable({
        "ajax": "Pastors/GetPastors",
        "columns": [
            { "data": "name" },
            {
                "render": function (data, type, row) {
                    return "<a href='Pastors/Edit/" + row.pastorId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Pastors/Remove/" + row.pastorId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#sections').DataTable({
        "ajax": "Sections/GetSections",
        "columns": [
            { "data": "name" },
            {
                "render": function (data, type, row) {
                    return "<a href='Sections/Edit/" + row.sectionId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Sections/Remove/" + row.sectionId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#pastorMessages').DataTable({
        "ajax": "PastorMessages/GetPastorMessages",
        "columns": [
            { "data": "title" },
            { "data": "pastorId" },
            {
                "render": function (data, type, row) {
                    return "<a href='PastorMessages/Edit/" + row.pastorMessageId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'PastorMessages/Remove/" + row.pastorMessageId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});

$(document).ready(function () {
    $('#testimonials').DataTable({
        "ajax": "Testimonials/GetTestimonials",
        "columns": [
            { "data": "author" },
            { "data": "content" },
            {
                "render": function (data, type, row) {
                    return "<a href='Testimonials/Edit/" + row.testimonialId + "'; class='btn btn-dark btn-sm'>Update</a><a href = 'Testimonials/Remove/" + row.testimonialId + "'; class='btn btn-danger btn-sm' > Delete</a >";
                }
            }
        ]
    });
});
