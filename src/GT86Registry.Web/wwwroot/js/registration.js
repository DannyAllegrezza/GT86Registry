$(document).ready(function () {
    console.log("registration.js init");
    // Populate the Manufacturer Select List
    $("#YearId").change(function () {
        $manufacturerId = $("#ManufacturerId");

        $.ajax({
            url: "/Account/GetManufacturersByYear",
            type: "GET",
            data: { year: $("#YearId").val() },
            traditional: true,
            success: function (result) {
                $manufacturerId.empty();
                $.each(result, function (i, item) {
                    $manufacturerId.append('<option value="' + item["value"] + '"> ' + item["text"] + ' </option>');
                })
            }
        });
    });

    // Populate the Model Select List
    $("#ManufacturerId").change(function () {
        $modelId = $("#VehicleModelId");

        $.ajax({
            url: "/Account/GetModels",
            type: "GET",
            data: { year: $("#YearId").val(), manufacturer: $("#ManufacturerId").val() },
            traditional: true,
            success: function (result) {
                $modelId.empty();
                $.each(result, function (i, item) {
                    $modelId.append('<option value="' + item["value"] + '"> ' + item["text"] + ' </option>');
                })
            }
        });
    });

});