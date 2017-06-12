(function (module) {
    AnalisisFactory.$inject = [
        'BaseFactory'
    ];
    function AnalisisFactory(BaseFactory) {
        var Analisis = [];
        Analisis.ObtenerCliente = function () {
            return BaseFactory.Obtener('/Analisis/ObtenerCliente');
        };
        Analisis.ObtenerMensajeXCliente = function () {
            return BaseFactory.Obtener('/Analisis/ObtenerMensajeXCliente');
        };
        Analisis.ObtenerResumenMes = function () {
            return BaseFactory.Obtener('/Analisis/ObtenerResumenMes');
        };
        Analisis.ObtenerResumenIntenciones = function () {
            return BaseFactory.Obtener('/Analisis/ObtenerResumenIntenciones');
        };
        return Analisis;
    }
    module.factory('AnalisisFactory', AnalisisFactory);
})(angular.module('uptbot'));
