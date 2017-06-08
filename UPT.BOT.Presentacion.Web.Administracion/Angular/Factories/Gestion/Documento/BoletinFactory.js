(function (module) {
    BoletinFactory.$inject = [
        'BaseFactory'
    ];
    function BoletinFactory(BaseFactory) {
        var Boletin = [];
        Boletin.ObtenerBoletin = function () {
            return BaseFactory.Obtener('/Gestion/ObtenerBoletin');
        };
        Boletin.GuardarBoletin = function (modelo) {
            return BaseFactory.Guardar('/Gestion/GuardarBoletin', modelo);
        };
        Boletin.EliminarBoletin = function (modelo) {
            return BaseFactory.Eliminar('/Gestion/EliminarBoletin', modelo);
        };
        return Boletin;
    }
    module.factory('BoletinFactory', BoletinFactory);
})(angular.module("uptbot"));