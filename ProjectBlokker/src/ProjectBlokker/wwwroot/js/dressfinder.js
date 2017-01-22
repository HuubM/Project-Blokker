$(function () {


    if ($("#maxprijs").val() < 100) {
        $("#maxprijs").val(100);
    }

    $("#slider").slider({
        change: function (event, ui) {
            console.log("ja: "+ $("#min") );
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
                var inputVal = handleIndex == 1 ? '#minvalue' : '#maxvalue';
                
                // zet de input valu voor min of max prijs
                $(inputVal).val(ui.value);

                $(label).html("€ " + ui.value).position({
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

    $('#min').html("€ " + $('#slider').slider('values', 0)).position({
        my: 'center top',
        at: 'center bottom',
        of: $('#slider span:eq(0)'),
        offset: "0, 10"
    });

    $('#max').html("€ " + $('#slider').slider('values', 1)).position({
        my: 'center top',
        at: 'center bottom',
        of: $('#slider span:eq(1)'),
        offset: "0, 10"
    });



    $("#dress-form").change(function (e) {
        filterDress();
    });


    $('body').on("click", 'a.naarPagina', function (e) {

        e.preventDefault();

        var pagina = $(this).attr("data-content");
        // zet pagina nummer
        $("#pagina").val(pagina);

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
        return false;
    }

});