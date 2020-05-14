var loginjs = {

    iniciar: function () {

        //$('#Input_Usu_Nombre').SinCaracteresEspeciales(helperjs.caracterespecialesLogin);
        //$('#Input_Usu_Contrasena').SinCaracteresEspeciales(helperjs.caracterespecialesLogin);

    },
    LoginIndex: function () {

        var ValidateInput = false;
        var orangeFormname = $.trim($('#Input_Usu_Nombre').val());
        var orangeFormpass = $.trim($('#Input_Usu_Contrasena').val());
        if (orangeFormname != '' && orangeFormname != null) {
            ValidateInput = true;
        }
        else {

            ValidateInput = false;
        }
        if (orangeFormpass != '' && orangeFormpass != null) {
            ValidateInput = true;
        }
        else {

            ValidateInput = false;
        }
        if (ValidateInput) {
            return true;
            //var request = {
            //    url: "Account/PageLogin",
            //    data: {
            //        u: orangeFormname,
            //        p: orangeFormpass
            //    },
            //    success: function (Response, textStatus, jqXhr) {
            //        debugger;
            //        if (Response.warning) {
            //            toastr.error(data.Message, 'Error de operacion', { positionClass: 'md-toast-bottom-right' }); $('#toast-container').attr('class', 'md-toast-bottom-right');
            //        }
            //        else {
            //            if (Response.success) {
            //                debugger;
            //                if (Response.data == "1") {

            //                    window.location.href = 'Home/index';


            //                }
            //                else {
            //                    toastr.error(jqXhr, 'Error al ingresar contraseña.', { positionClass: 'md-toast-bottom-right' }); $('#toast-container').attr('class', 'md-toast-bottom-right');
            //                }

            //            }
            //        }
            //    },
            //    error: function (data, textStatus, jqXhr) {
            //        toastr.error(jqXhr, 'Error al procesar solicitud', { positionClass: 'md-toast-bottom-right' }); $('#toast-container').attr('class', 'md-toast-bottom-right');

            //    }
            //};
            //helperjs.ajaxSend(request);
        }
        else {
            toastr.info('Ingrese Usuario o Contraseña', 'Validación.', { positionClass: 'md-toast-bottom-right' }); $('#toast-container').attr('class', 'md-toast-bottom-right');
            return false;
        }
    }
}