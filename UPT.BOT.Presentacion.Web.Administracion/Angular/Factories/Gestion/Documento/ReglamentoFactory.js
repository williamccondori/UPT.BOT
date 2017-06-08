(function (module) {
    ReglamentoFactory.$inject = [
        'BaseFactory'
    ];
    function ReglamentoFactory(BaseFactory) {
        var Reglamento = [];
        Reglamento.ObtenerReglamento = function () {
            return BaseFactory.Obtener('/Gestion/ObtenerReglamento');
        };
        Reglamento.GuardarReglamento = function (modelo) {
            return BaseFactory.Guardar('/Gestion/GuardarReglamento', modelo);
        };
        Reglamento.EliminarReglamento = function (modelo) {
            return BaseFactory.Eliminar('/Gestion/EliminarReglamento', modelo);
        };
        return Reglamento;
    }
    module.factory('ReglamentoFactory', ReglamentoFactory);
})(angular.module("uptbot"));