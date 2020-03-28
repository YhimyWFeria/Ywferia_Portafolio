$.ajaxSetup({ cache: false });

$(document).ajaxStart(function () {
    //  helperjs.showWait();
});

$(document).ajaxStop(function () {
    // helperjs.hideWait();
});

var helperjs = {
    hideWait: function () {
        $("#wait").hide();
        $("#waitImg").hide();
    },

    caracterespecialesLogin: "'</*#$@%&(!|°¬~^¡?¿)>-_\\,;{}[]+-=´¨" + '" ',
    caracterespeciales: "'></*#$@%&(!|°¬~^¡?¿)>-_\\,.;{}[]+-=´¨" + '"',
    caracteresnumeros: "0123456789",
    caracterespecialesGeneral: "°¬~^<>\\'-" + '"',

  
    ajaxSend: function (request) {

        var forgeryToke = $("input[name='__RequestVerificationToken']").val();

        if (forgeryToke != undefined) {
            if (request.data == undefined)
                request.data = {};
            request.data.__RequestVerificationToken = forgeryToke;
        }
        var asyn = true;
        if (typeof (request.async) != 'undefined' && request.async != null) asyn = request.async;
        $.ajax({
            url: request.url,
            type: (request.type == null) ? "POST" : request.type,
            data: request.data,
            async: asyn,
            datatype: request.datatype,
            contentType: request.contentType,
            success: function (data, textStatus, jqXhr) {
                request.success(data, textStatus, jqXhr);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                request.error(jqXhr, textStatus, errorThrown);
            },
            beforeSend: function () {

                //$('#loadingpage').show()
            },
            complete: function () {
                //$('#loadingpage').hide()
            }
        });
    },

    fromSubmit: function (url) {

        var form = document.createElement("FORM");
        form.action = url;
        form.method = "POST";

        var forgeryToke = $("input[name='__RequestVerificationToken']").val();

        // ReSharper disable once ConditionIsAlwaysConst
        if (forgeryToke != undefined && forgeryToke != null) {
            var input = document.createElement("INPUT");
            input.type = "hidden";
            input.name = '__RequestVerificationToken';
            input.value = forgeryToke;
            form.appendChild(input);
        }

        document.body.appendChild(form);
        form.submit();
    },

    setPostUrl: function (url, params1, params2, params3) {

        var form = document.createElement("FORM");
        form.action = url;
        form.method = 'POST';
        //IMPORTANTE: No debe tener ningun tipo de serializacion
        var indexQM = url.indexOf("?");
        if (indexQM >= 0) {
            // the URL has parameters => convert them to hidden form inputs
            var params = url.substring(indexQM + 1).split("&");
            for (var i = 0; i < params.length; i++) {
                var keyValuePair = params[i].split("=");
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair[0];
                if (input.name != '__RequestVerificationToken') {
                    input.value = keyValuePair[1];
                    form.appendChild(input);
                }
            }
        }

        // En caso se envia el array de serializeArray
        if (params1 != undefined)
            for (var i = 0; i < params1.length; i++) {
                var keyValuePair = params1[i];
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair.name;
                if (input.name != '__RequestVerificationToken') {
                    input.value = keyValuePair.value;
                    form.appendChild(input);
                }
            }

        // En caso se envia el array de serializeArray
        if (params2 != undefined)
            for (var i = 0; i < params2.length; i++) {
                var keyValuePair = params2[i];
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair.name;
                if (input.name != '__RequestVerificationToken') {
                    input.value = keyValuePair.value;
                    form.appendChild(input);
                }
            }

        // En caso se envia el array de serializeArray
        if (params3 != undefined)
            for (var i = 0; i < params3.length; i++) {
                var keyValuePair = params3[i];
                var input = document.createElement("INPUT");
                input.type = "hidden";
                input.name = keyValuePair.name;
                input.value = keyValuePair.value;
                form.appendChild(input);
            }

        var forgeryToke = $("input[name='__RequestVerificationToken']").val();

        if (forgeryToke != undefined && forgeryToke != null) {
            var input = document.createElement("INPUT");
            input.type = "hidden";
            input.name = '__RequestVerificationToken';
            input.value = forgeryToke;

            form.appendChild(input);
        }

        document.body.appendChild(form);
        helperjs.showWait();
        form.submit();
    },

    subMenu: function (event) {
        // Avoid following the href location when clicking
        event.preventDefault();
        // Avoid having the menu to close when clicking
        event.stopPropagation();
        // opening the one you clicked on
        $('li.dropdown-submenu').removeClass('open');
        $(this).parent().addClass('open');
        var menu = $(this).parent().find("ul");
        var menupos = menu.offset();
        if ((menupos.left + menu.width()) + 30 > $(window).width()) {
            var newpos = -menu.width();
        } else {
            var newpos = $(this).parent().width();
        }
        menu.css({ left: newpos });
    },

    noPegar: function () {


        $(".no-copy-paste").bind('paste', function (e) {

            var dataAPegar = e.originalEvent.clipboardData.getData('text/html');
            dataAPegar = dataAPegar.replace(new RegExp("°", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("¬", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("~", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("^", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("<", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp(">", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("/", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp('"', "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("@", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("#", "g"), '');
            //dataAPegar = dataAPegar.replace(new RegExp('*', "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("%", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("&", "g"), '');
            //dataAPegar = dataAPegar.replace(new RegExp("(", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("!", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("|", "g"), '');
            //dataAPegar = dataAPegar.replace(new RegExp("?", "g"), '');
            //dataAPegar = dataAPegar.replace(new RegExp("¿", "g"), '');
            //dataAPegar = dataAPegar.replace(new RegExp(")", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("-", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("{", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("}", "g"), '');
            //dataAPegar = dataAPegar.replace(new RegExp("[", "g"), '');
            //dataAPegar = dataAPegar.replace(new RegExp("]", "g"), '');
            //dataAPegar = dataAPegar.replace(new RegExp("+", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("=", "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp('´', "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp('¨', "g"), '');
            dataAPegar = dataAPegar.replace(new RegExp("'", "g"), '');
            var datosAnteriores = $(this).val();
            $(this).val(datosAnteriores + dataAPegar);
            return false;
        });


        $(".no-copy-paste").SinCaracteresEspeciales(helperjs.caracterespecialesGeneral);
        $(".no-copy-paste").attr('autocomplete', 'off');
    },

    enums: {
        mensajeAlerta: {
            grabar: '¿Estás seguro de grabar?',
            accion: '¿Estás seguro de realizar esta acción?',
            grabarFlujo: '¿Estás seguro de iniciar con el proceso de aprobación?'

        }
    },
    validarInputpastecaractercaracterespeciales: function (e) {

        //var oldValue = inputField.text();
        if (e.type == 'paste') {
            var datathis = event.clipboardData.getData('text/plain');

            if (datathis.match(/[^A-Z-a-z.]/g)) {
                return false;
            }
        }
        else if (e.type == 'drop') {
            return false;
        }
    }
};
//Extensión de caracteres especiales
(function (a) {
    a.fn.SinCaracteresEspeciales = function (b) {
        a(this).on({
            keypress: function (a) {
                var c = a.which,
                    d = a.keyCode,
                    e = String.fromCharCode(c).toLowerCase(),
                    f = b;
                (-1 == f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault();
            }
        });
    };
})(jQuery);