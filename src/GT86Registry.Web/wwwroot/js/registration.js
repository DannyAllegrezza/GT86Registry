$(document).ready(function () {
    console.log("registration.js init - test VIN JF1ZNAA12J8701217");

    registerVinEventListener();
    setShowMoreEventListener();

    function registerVinEventListener() {
        $("#VIN").keyup(function () {
            var vin = $(this).val();

            if (isVinInputValid(vin)) {
                $.ajax({
                    url: `/api/vehicles/${vin}`,
                    type: "GET",
                    traditional: true,
                    success: function (result) {
                        console.log(`SUCCESS! -- ${result}`);
                        renderSuccessMessage(result);
                    },
                    error: function (result) {
                        console.log(`ERROR! -- ${result}`);
                        renderErrorMessage(result);
                    }
                });
            }
        });
    }

    function setShowMoreEventListener() {
        $("#more-info").hide();
        $("#show-more-info").click(() => {
            $("#more-info").slideToggle();
        });
    }

    function isVinInputValid(vin) {
        return vin.length === 17;
    }

    function renderSuccessMessage(result) {
        var vehicleText = `We've successfully validated your ${result.modelYear} ${result.make} ${result.model}!`;

        $("#vehicle-details").text(vehicleText);
    }

    function renderErrorMessage(result) {
        var vehicleText = `The VIN you provided is invalid. Please try again.`;

        $("#vehicle-details").text(vehicleText);
    }
});