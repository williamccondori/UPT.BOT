(function (module) {

    ObjetoFactory.$inject = ['BaseFactory'];

    function ObjetoFactory(BaseFactory) {

        var Objeto = [];

        Objeto.ObtenerObjeto = function () {
            return BaseFactory.Obtener('/Configuracion/ObtenerObjeto');
        };
        Objeto.GuardarObjeto = function (modelo) {
            return BaseFactory.Guardar('/Configuracion/GuardarObjeto', modelo);
        };
        Objeto.EliminarObjeto = function (modelo) {
            return BaseFactory.Eliminar('/Configuracion/EliminarObjeto', modelo);
        };

        return Objeto;
    }

    module.factory('ObjetoFactory', ObjetoFactory);

})(angular.module("uptbot"));