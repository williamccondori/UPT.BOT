(function (module) {
    EventoFactory.$inject = [
        'BaseFactory'
    ];
    function EventoFactory(BaseFactory) {
        var Evento = [];
        Evento.ObtenerEvento = function () {
            return BaseFactory.Obtener('/Gestion/ObtenerEvento');
        };
        Evento.GuardarEvento = function (modelo) {
            return BaseFactory.Guardar('/Gestion/GuardarEvento', modelo);
        };
        Evento.EliminarEvento = function (modelo) {
            return BaseFactory.Eliminar('/Gestion/EliminarEvento', modelo);
        };
        return Evento;
    }
    module.factory('EventoFactory', EventoFactory);
})(angular.module("uptbot"));