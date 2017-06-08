(function (module) {
    ComunicadoFactory.$inject = [
        'BaseFactory'
    ];
    function ComunicadoFactory(BaseFactory) {
        var Comunicado = [];
        Comunicado.ObtenerComunicado = function () {
            return BaseFactory.Obtener('/Gestion/ObtenerComunicado');
        };
        Comunicado.GuardarComunicado = function (modelo) {
            return BaseFactory.Guardar('/Gestion/GuardarComunicado', modelo);
        };
        Comunicado.EliminarComunicado = function (modelo) {
            return BaseFactory.Eliminar('/Gestion/EliminarComunicado', modelo);
        };
        return Comunicado;
    }
    module.factory('ComunicadoFactory', ComunicadoFactory);
})(angular.module("uptbot"));