(function (module) {
    GaleriaFactory.$inject = [
        'BaseFactory'
    ];
    function GaleriaFactory(BaseFactory) {
        var Galeria = [];
        Galeria.ObtenerGaleria = function () {
            return BaseFactory.Obtener('/Gestion/ObtenerGaleria');
        };
        Galeria.GuardarGaleria = function (modelo) {
            return BaseFactory.Guardar('/Gestion/GuardarGaleria', modelo);
        };
        Galeria.EliminarGaleria = function (modelo) {
            return BaseFactory.Eliminar('/Gestion/EliminarGaleria', modelo);
        };
        return Galeria;
    }
    module.factory('GaleriaFactory', GaleriaFactory);
})(angular.module("uptbot"));