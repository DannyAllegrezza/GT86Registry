$(document).ready(function () {
    console.log("registration.js init");

    setShowMoreEventListener();
    configureManufacturerSelectList();
    configureModelSelectList();
    configureColorsSelectList();
    configureTransmissionSelectList();

    function FetchData(url, data) {
        // todo (dca): can easily refactor this file so we just call one function to make get requests
    }

    function setShowMoreEventListener() {
        $("#more-info").hide();
        $("#show-more-info").click(() => {
            $("#more-info").slideToggle();
        })
    }

    function configureManufacturerSelectList() {
        $("#YearId").change(function () {
            $manufacturerId = $("#ManufacturerId");

            $.ajax({
                url: "/Account/GetManufacturersByYear",
                type: "GET",
                data: { year: $("#YearId option:selected").text() },
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
    }

    function configureModelSelectList() {
        $("#ManufacturerId").change(function () {
            $modelId = $("#VehicleModelId");
            $manufId = $("#ManufacturerId").val();

            $.ajax({
                url: "/Account/GetModels",
                type: "GET",
                data: { year: $("#YearId option:selected").text(), manufacturerId: $("#ManufacturerId").val() },
                traditional: true,
                success: function (result) {
                    $modelId.empty();
                    $.each(result, function (i, item) {
                        $modelId.append('<option value="' + item["value"] + '"> ' + item["text"] + ' </option>');
                    })
                }
            });
        });
    }

    function configureColorsSelectList() {
        $("#VehicleModelId").change(function () {
            $colorId = $("#ColorId");

            $.ajax({
                url: "/Account/GetColors",
                type: "GET",
                data: { year: $("#YearId option:selected").text(), modelId: $("#VehicleModelId").val() },
                traditional: true,
                success: function (result) {
                    $colorId.empty();
                    $.each(result, function (i, item) {
                        $colorId.append('<option value="' + item["value"] + '"> ' + item["text"] + ' </option>');
                    })
                }
            });
        });
    }

    function configureTransmissionSelectList() {
        $("#VehicleModelId").change(function () {
            $transmissionId = $("#TransmissionId");

            $.ajax({
                url: "/Account/GetTransmissions",
                type: "GET",
                data: { year: $("#YearId option:selected").text(), modelId: $("#VehicleModelId").val() },
                traditional: true,
                success: function (result) {
                    $transmissionId.empty();
                    $.each(result, function (i, item) {
                        $transmissionId.append('<option value="' + item["value"] + '"> ' + item["text"] + ' </option>');
                    })
                }
            });
        });
    }
});