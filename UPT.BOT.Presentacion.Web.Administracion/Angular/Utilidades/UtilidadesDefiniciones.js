$(document).ready(function () {
    $("#img_cargando").hide();

    $(document).ajaxStart(function () {
        $("#img_cargando").show();
    });

    $(document).ajaxSuccess(function () {
        $("#img_cargando").hide("normal");
    });

    $(document).ajaxError(function () {
        $("#img_cargando").hide("normal");
    });
});

var EnvioHttp = {
    Get: "GET",
    Post: "POST"
}

var MensajeConfirmacion = {
    Guardar: "¿Desea guardar los cambios?",
    Eliminar: "¿Desea eliminar este registro?",
    Cancelar: "¿Desea cancelar y deshacer los cambios?",
    Aceptar: "¿Desea aceptar el documento?",
    Devolver: "¿Desea devolver el documento?"
}

var MensajeRespuesta = {
    Exito: "Los datos se guardaron correctamente.",
    Error: "Se ha generado un error."
}

var EstadoObjeto = {
    SinCambios: 0,
    Nuevo: 1,
    Modificado: 2,
    Borrado: 3
};

var EstadoFormulario = {
    Default: 0,
    Nuevo: 1,
    Editar: 2
}
