$(document).ready(function () {
    $("#DepartureDate").on("change",
        function () {
            var ArrivalDate = $("#ArrivalDate").val();
            var DepartureDate = $(this).val();
            if (Date.parse(DepartureDate) <= Date.parse(ArrivalDate)) {
                $(this).val("");
                alert("Дата выезда должна быть позже даты заселения");
            }
            if (ArrivalDate == "") {
                $(this).val("");
                alert("Сначала выберите дату заселения");
            }
        });

    $("#ArrivalDate").on("change",
        function () {
            var ArrivalDate = new Date($(this).val());
            var DepartureDate = new Date($("#DepartureDate").val());
            var DateNow = new Date();
            if (ArrivalDate.getDate() < DateNow.getDate()) {
                $(this).val("");
                alert("Выберите корректную дату заселения");
            }
            if (ArrivalDate.getDate() == DepartureDate.getDate()) {
                $(this).val("");
                $("#DepartureDate").val("");
                alert("Дата заселенияне может совпадать с датой выезда");
            }
        });
});