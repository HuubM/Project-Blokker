﻿
function GetAllDates() {
    $.ajax({
        type: "POST",
        url: "/Afspraak/getDate",
        success: function (result) {
            //alert("Succes");

            var tempResult = result;

            for (i = 0; i < tempResult.length; i++) {
                tempDate = tempResult[i].split("T", 1);
                var pieces = tempDate[0].split("-");
                pieces = pieces.reverse();
                pieces = pieces.join("-");
                tempDate[0] = pieces;
                tempResult[i] = tempDate[0];
            }
            var disabledDates = tempResult;

            console.log(tempResult);
            console.log(disabledDates);
            
            disabledDatesList = disabledDates;
            
        },

        async: false

    });
};

function contains(a, obj) {
    var i = a.length;
    while (i--) {
        if (a[i] === obj) {
            return true;
        }
    }
    return false;
}


$(function () {
    GetAllDates();
          /*
    $("#repeatEmail").rules("add", {
        equalTo: "#Email",
        messages: {
            equalTo: "E-mail adres is niet hetzelfde.",
            required: "E-mail adres is niet hetzelfde."
        }
    });
    */
     //Datepicker nl waarden
    $.fn.datepicker.dates['nl'] = {
		days: ["zondag", "maandag", "dinsdag", "woensdag", "donderdag", "vrijdag", "zaterdag"],
		daysShort: ["zo", "ma", "di", "wo", "do", "vr", "za"],
		daysMin: ["ZO", "MA", "DI", "WO", "DO", "VR", "ZA"],
		months: ["JANUARI", "FEBRUARI", "MAART", "APRIL", "MEI", "JUNI", "JULI", "AUGUSTUS", "SEPTEMBER", "OKTOBER", "NOVEMBER", "DECEMBER"],
		monthsShort: ["jan", "feb", "mrt", "apr", "mei", "jun", "jul", "aug", "sep", "okt", "nov", "dec"],
		today: "Vandaag",
		monthsTitle: "Maanden",
		clear: "Wissen",
		weekStart: 1,
		format: "dd-mm-yyyy"
    };
    

    var weekday = ["ZO", "MA", "DI", "WO", "DO", "VR", "ZA"];
    var months = ["JANUARI", "FEBRUARI", "MAART", "APRIL", "MEI", "JUNI", "JULI", "AUGUSTUS", "SEPTEMBER", "OKTOBER", "NOVEMBER", "DECEMBER"];

     //Datepicker initialisatie
    $('#datetimepicker').datepicker({
        format: 'dd/mm/yyyy',
        language: 'nl',
        startDate: new Date(),
        minViewMode: 0,
        maxViewMode: 0,
        datesDisabled: disabledDatesList
        
    });
    //
    $('#datetimepicker').datepicker()
    .on('changeDate', function (e) {
        $('#selectTime').slideDown();
    });

     //Van stap 1 naar stap 2
    $('#naar-gegevensinvullen').on("click", function (e) {
        
        
        var dateInput = $('#datumAfpsraak').val();
        var date = new Date(dateInput);
        var tijd = $('input[name=tijdstip]:checked', '#afspraakgegevens').val();

        console.log("tijd "+tijd);
        $('#eindafspraak').val($.format.date(dateInput,"dd-MM-yyyy"));
        console.log("eindafsrpaak " + $('#eindafspraak').val());
        
        $('#eindtijd').val(tijd);



        $('.gekozen-datum-tijd').text(weekday[date.getDay()] + " " + date.getDate() + " " + months[date.getMonth()] + " " + date.getFullYear() + " OM " + tijd + "U");

        $('#datum-tijd').slideUp();
        $('#tijd-kiezen').slideUp();
        $('#datum-kiezen').slideUp();
        $('#gekozen-tijd-datum').slideDown();
        $('#gegevens-invullen').slideDown();

        $(".circle2").addClass("active");
        $(".circle1").removeClass("active");

        e.preventDefault();
    });

     //Terug naar stap 1 vanuit stap 2
    $('#terug-stap1').on("click", function (e) {

        $('#datum-tijd').slideDown();
        $('#tijd-kiezen').slideDown();
        $('#gekozen-tijd-datum').slideUp();
        $('#gegevens-invullen').slideUp();

        $(".circle1").addClass("active");
        $(".circle2").removeClass("active");

        e.preventDefault();
    });


     //Van stap 2 naar stap 3
    $('#naar-gegevenscontroleren').on("click", function (e) {

         //Als valid, dan mag die naar stap 3
        if ($('#afspraakgegevens').valid()) {

             //Zet gegevens in controle tabel
            $('#gekozennaam').text($('#Naam').val());
            $('#gekozentrouwdatum').text($('#TrouwDatum').val());
            $('#gekozentelefoon').text($('#TelNr').val());
            $('#gekozenemail').text($('#Email').val());


            $('#gekozen-tijd-datum').slideUp();
            $('#gegevens-invullen').slideUp();
            $('#gegevens-bevestigen').slideDown();
            $('#gegevens-controleren').slideDown();

            $(".circle3").addClass("active");
            $(".circle2").removeClass("active");

            e.preventDefault();
        }
    });

     //Terug naar stap 2 vanuit stap 3
    $('#terug-stap2').on("click", function (e) {

        $('#gekozen-tijd-datum').slideDown();
        $('#gegevens-invullen').slideDown();
        $('#gegevens-bevestigen').slideUp();
        $('#gegevens-controleren').slideUp();

        $(".circle2").addClass("active");
        $(".circle3").removeClass("active");

        e.preventDefault();
    });


     //Bij tijd selecteren in stap 1
    $('#selectTime').on("click", function (e) {

        var dateInput = $('#datumAfpsraak').val();
        var date = new Date(dateInput);

        $('#gekozen-datum').text(weekday[date.getDay()] + " " + date.getDate() + " " + months[date.getMonth()] + " " + date.getFullYear());

        $('#datum-kiezen').slideUp();
        e.preventDefault();

        $('#tijd-kiezen').slideDown();
        e.preventDefault();
    });

     //Terug naar datum in stap 1
    $('#tijd-terug-datum').on("click", function (e) {

        $('#datum-kiezen').slideDown();
        e.preventDefault();

        $('#tijd-kiezen').slideUp();
        e.preventDefault();
    });

    //Input waarden toevoegen bij kiezen tijd
    $('input:radio[name="tijdstip"]').change(
    function () {
        if ($(this).is(':checked')) {
            $('#naar-gegevensinvullen').slideDown();
        }
    });
    
    
    //Input waarden toevoegen bij kiezen datum
    $('#datetimepicker').on("changeDate", function () {

        var dateInput = $('#datumAfpsraak').val();
        var test = dateInput.toString();
        var pieces = test.split("/");

        var option = {
            url: '/Afspraak/pickedDate',
            data: ({ afspraakdag: parseInt(pieces[0]), afspraakmaand: parseInt(pieces[1]), afspraakjaar: parseInt(pieces[2]) }),
            method: 'get',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8'
        };

        $.ajax(option).success(function (data) {
            $("#0930").prop("checked", false);
            $("#1200").prop("checked", false);
            $("#1500").prop("checked", false);
            if (contains(data, '09:30')) {
                $("#0930").prop("disabled", true);
            }
            else
                $("#0930").prop("disabled", false);
            if (contains(data, '12:00')) {
                $("#1200").prop("disabled", true);
            }
            else
                $("#1200").prop("disabled", false);
            if (contains(data, '15:00')) {
                $("#1500").prop("disabled", true);
            }
            else
                $("#1500").prop("disabled", false);


        })
        $('#datumAfpsraak').val(
           $('#datetimepicker').datepicker('getDate')
        );
    });
});

