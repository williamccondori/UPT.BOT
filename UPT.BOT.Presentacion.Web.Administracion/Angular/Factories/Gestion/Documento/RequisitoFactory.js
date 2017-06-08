(function (module) {
    RequisitoFactory.$inject = [
        'BaseFactory'
    ];
    function RequisitoFactory(BaseFactory) {
        var Requisito = [];
        Requisito.ObtenerRequisito = function () {
            return BaseFactory.Obtener('/Gestion/ObtenerRequisito');
        };
        Requisito.GuardarRequisito = function (modelo) {
            return BaseFactory.Guardar('/Gestion/GuardarRequisito', modelo);
        };
        Requisito.EliminarRequisito = function (modelo) {
            return BaseFactory.Eliminar('/Gestion/EliminarRequisito', modelo);
        };
        return Requisito;
    }
    module.factory('RequisitoFactory', RequisitoFactory);
})(angular.module("uptbot"));