(function (module) {

    AnalisisFactory.$inject = ["$resource"];


    function AnalisisFactory($resource) {

        var AnalisisController = [];

        AnalisisController.ObtenerCliente = function () {
            return $resource('/Analisis/ObtenerCliente', {}, {
                Get: {
                    method: 'GET',
                    isArray: false
                }
            }).Get();
        };

        AnalisisController.ObtenerMensajeXCliente = function () {
            return $resource('/Analisis/ObtenerMensajeXCliente', {}, {
                Get: {
                    method: 'GET',
                    isArray: false
                }
            }).Get();
        };
        

        return AnalisisController;
    }

    module.factory("AnalisisFactory", AnalisisFactory);

})(angular.module("uptAdministracion"));