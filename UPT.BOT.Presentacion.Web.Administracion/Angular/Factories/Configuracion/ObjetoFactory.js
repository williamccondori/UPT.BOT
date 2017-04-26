(function (module) {

    ObjetoFactory.$inject = ["$resource"];

    function ObjetoFactory($resource) {

        var GestionController = [];

        GestionController.ObtenerObjeto = function () {
            return $resource('/Gestion/ObtenerObjeto', {}, {
                Get: {
                    method: 'GET',
                    isArray: false
                }
            }).Get();
        };

        GestionController.GuardarObjeto = function (Objeto) {
            return $resource('/Gestion/GuardarObjeto', {}, {
                Post: {
                    method: 'POST',
                    isArray: false
                }
            }).Post(Objeto);
        };

        return GestionController;
    }

    module.factory("ObjetoFactory", ObjetoFactory);

})(angular.module("uptAdministracion"));