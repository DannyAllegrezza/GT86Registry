$(document).ready(function () {
    console.log("registration.js init");
    // Populate the Manufacturer Select List
    $("#YearId").change(function () {
        $manufacturerId = $("#ManufacturerName");

        $.ajax({
            url: "/Account/GetManufacturersByYear",
            type: "GET",
            data: { year: $("#YearId").val() },
            traditional: true,
            success: function (result) {
                console.log(result);
                $manufacturerId.empty();
                $.each(result, function (i, item) {
                    $manufacturerId.append('<option value="' + item["value"] + '"> ' + item["text"] + ' </option>');
                })
            }
        });
    });

    // Populate the Model Select List
    $("#ManufacturerName").change(function () {
        $modelId = $("#VehicleModelName");

        $.ajax({
            url: "/Account/GetModels",
            type: "GET",
            data: { year: $("#YearId").val(), manufacturer: $("#ManufacturerName").val() },
            traditional: true,
            success: function (result) {
                $modelId.empty();
                $.each(result, function (i, item) {
                    $modelId.append('<option value="' + item["value"] + '"> ' + item["text"] + ' </option>');
                })
            }
        });
    });

    // Populate the Colors Select List
    $("#VehicleModelName").change(function () {
        $colorId = $("#ColorName");

        $.ajax({
            url: "/Account/GetColors",
            type: "GET",
            data: { year: $("#YearId").val(), model: $("#VehicleModelName").val() },
            traditional: true,
            success: function (result) {
                $colorId.empty();
                $.each(result, function (i, item) {
                    $colorId.append('<option value="' + item["value"] + '"> ' + item["text"] + ' </option>');
                })
            }
        });
    });


});