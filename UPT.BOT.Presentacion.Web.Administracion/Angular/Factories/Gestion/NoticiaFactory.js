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

        GestionController.EliminarNoticia = function (Noticia) {
            return $resource('/Gestion/EliminarNoticia', {}, {
                Delete: {
                    method: 'DELETE',
                    isArray: false
                }
            }).Delete(Noticia);
        };

        return GestionController;
    }

    module.factory("NoticiaFactory", NoticiaFactory);

})(angular.module("uptAdministracion"));