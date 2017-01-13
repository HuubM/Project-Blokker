﻿$(function () {


    if ($("#maxprijs").val() < 100) {
        $("#maxprijs").val(100);
    }

    $("#slider").slider({
        change: function (event, ui) {

            $("#minvalue").val($("#min").text());
            $("#maxvalue").val($("#max").text());
            filterDress();
        },
        range: true,
        min: 0,
        max: $("#maxprijs").val(),
        values: [0, $("#maxprijs").val()],
        slide: function (event, ui) {
            var delay = function () {
                //var handleIndex = $(ui.handle).data('index.uiSliderHandle');
                var handleIndex = $(ui.handle).index();
                var label = handleIndex == 1 ? '#min' : '#max';
                $(label).html(ui.value).position({
                    my: 'center top',
                    at: 'center bottom',
                    of: ui.handle,
                    offset: "0, 10"
                });
            };

            // wait for the ui.handle to set its position
            setTimeout(delay, 5);
        }
    });

    $('#min').html($('#slider').slider('values', 0)).position({
        my: 'center top',
        at: 'center bottom',
        of: $('#slider span:eq(0)'),
        offset: "0, 10"
    });

    $('#max').html($('#slider').slider('values', 1)).position({
        my: 'center top',
        at: 'center bottom',
        of: $('#slider span:eq(1)'),
        offset: "0, 10"
    });



    $("#dress-form").change(function () {
        filterDress();
    });

    function filterDress() {
        $.ajax({
            type: "POST",
            url: "/dressfinder/Filter",
            data: $("#dress-form").serialize(),
            datatype: "html",
            success: function (data) {
                $('#dressfinder-dres').html(data);
            }
        });
    }

});