(function (module) {

    NoticiaFactory.$inject = ["$resource"];

    function NoticiaFactory($resource) {

        var GestionController = [];

        GestionController.ObtenerNoticia = function () {
            return $resource('/Gestion/ObtenerNoticia', {}, {
                Get: {
                    method: 'GET',
                    isArray: false
                }
            }).Get();
        };

        GestionController.GuardarNoticia = function (Noticia) {
            return $resource('/Gestion/GuardarNoticia', {}, {
                Post: {
                    method: 'POST',
                    isArray: false
                }
            }).Post(Noticia);
        };

        return GestionController;
    }

    module.factory("NoticiaFactory", NoticiaFactory);

})(angular.module("uptAdministracion"));