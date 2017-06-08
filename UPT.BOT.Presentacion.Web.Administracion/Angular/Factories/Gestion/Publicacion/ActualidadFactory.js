(function (module) {
    ActualidadFactory.$inject = [
        'BaseFactory'
    ];
    function ActualidadFactory(BaseFactory) {
        var Actualidad = [];
        Actualidad.ObtenerActualidad = function () {
            return BaseFactory.Obtener('/Gestion/ObtenerActualidad');
        };
        Actualidad.GuardarActualidad = function (modelo) {
            return BaseFactory.Guardar('/Gestion/GuardarActualidad', modelo);
        };
        Actualidad.EliminarActualidad = function (modelo) {
            return BaseFactory.Eliminar('/Gestion/EliminarActualidad', modelo);
        };
        return Actualidad;
    }
    module.factory('ActualidadFactory', ActualidadFactory);
})(angular.module("uptbot"));