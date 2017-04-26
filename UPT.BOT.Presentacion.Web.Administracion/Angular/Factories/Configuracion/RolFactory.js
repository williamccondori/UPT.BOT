(function (module) {

    RolFactory.$inject = ["$resource"];

    function RolFactory($resource) {

        var GestionController = [];

        GestionController.ObtenerRol = function () {
            return $resource('/Configuracion/ObtenerRol', {}, {
                Get: {
                    method: 'GET',
                    isArray: false
                }
            }).Get();
        };

        GestionController.GuardarRol = function (Rol) {
            return $resource('/Configuracion/GuardarRol', {}, {
                Post: {
                    method: 'POST',
                    isArray: false
                }
            }).Post(Rol);
        };

        return GestionController;
    }

    module.factory("RolFactory", RolFactory);

})(angular.module("uptAdministracion"));