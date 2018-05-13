$(function () {

    PeopleTable = $('#PeopleTable').DataTable({
        searching: false,
        lengthChange: false,
        AutoWidth: false,
    });
    PrepareValidationRules();

});


function PrepareValidationRules() {
    $("#person-form").validate({
        debug: true,
        rules: {
            'Person.Telephone': {
                number: true,
            },
            'Person.FirstName': {
                required: true,
            },
            'Person.LastName': {
                required: true,
            },
        },
        messages: {
            'Person.Telephone': {
                number: "The telephone must be a number",
            },
            'Person.FirstName': {
                required: "Please enter first name",
            },
            'Person.LastName': {
                required: "Please enter last nam",
            },
        },
        submitHandler: function (form) {
            CallForPersonData();
        }
    });
}

function CallForPersonData() {
    $.ajax({
        type: "POST",
        url: "Person/SavePerson",
        cache: true,
        data: JSON.stringify({
            FirstName: $('input[name="Person.FirstName"]').val(),
            LastName: $('input[name="Person.LastName"]').val(),
            Telephone: $('input[name="Person.Telephone"]').val(),
            Gender: "Male",
            Age: "22"

        }),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            location.reload();
        },
        error: function () {
            $('#errorModal').modal('show');
        }
    });
    return false;
}


