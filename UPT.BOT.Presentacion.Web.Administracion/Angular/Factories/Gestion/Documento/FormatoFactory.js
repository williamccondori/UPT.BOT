(function (module) {
    FormatoFactory.$inject = [
        'BaseFactory'
    ];
    function FormatoFactory(BaseFactory) {
        var Formato = [];
        Formato.ObtenerFormato = function () {
            return BaseFactory.Obtener('/Gestion/ObtenerFormato');
        };
        Formato.GuardarFormato = function (modelo) {
            return BaseFactory.Guardar('/Gestion/GuardarFormato', modelo);
        };
        Formato.EliminarFormato = function (modelo) {
            return BaseFactory.Eliminar('/Gestion/EliminarFormato', modelo);
        };
        return Formato;
    }
    module.factory('FormatoFactory', FormatoFactory);
})(angular.module("uptbot"));