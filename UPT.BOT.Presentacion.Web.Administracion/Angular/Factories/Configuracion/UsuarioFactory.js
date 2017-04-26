(function (module) {

    UsuarioFactory.$inject = ["$resource"];

    function UsuarioFactory($resource) {

        var GestionController = [];

        GestionController.ObtenerUsuario = function () {
            return $resource('/Configuracion/ObtenerUsuario', {}, {
                Get: {
                    method: 'GET',
                    isArray: false
                }
            }).Get();
        };

        GestionController.GuardarUsuario = function (Usuario) {
            return $resource('/Configuracion/GuardarUsuario', {}, {
                Post: {
                    method: 'POST',
                    isArray: false
                }
            }).Post(Usuario);
        };

        return GestionController;
    }

    module.factory("UsuarioFactory", UsuarioFactory);

})(angular.module("uptAdministracion"));