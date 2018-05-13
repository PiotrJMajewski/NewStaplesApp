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
        error: function (xhr, status, error) {
            var errorMessage = xhr.status + ': ' + xhr.statusText
            //PrepareErrorMessage(xhr.responseText);
            console.log('error');
        }
    });
    return false;
}

function PropagatePeopleTable() {

    var tbody = $('#PeopleTable').find('tbody');
    tbody.append('<tr><td>' + $('input[name="Person.FirstName"]').val() + '</td><td>' + $('input[name="Person.LastName"]').val()+'</td></tr>');

    //var price = $('input[name=priceInput]').val();
    //var tbody = energyConsumptionRecord.find('tbody');
    //tbody.find('tr').remove();

    //$.each(data, function (index, value) {
    //    tbody.append('<tr><td class="daylyValue">' + value.day + '</td><td class="monthlyValue">' + value.month + '</td><td>' + value.year + '</td><td>' + value.consumption.toFixed(2) + '</td><td>' + (value.consumption * price).toFixed(2) + '</td></tr>');
    //});

    //SetReportTableColumnsVisibility(data);

    PeopleTable = $('#PeopleTable').DataTable({
        searching: false,
        lengthChange: false,
        AutoWidth: false,
    });

    //energyConsumptionRecord.show();
}