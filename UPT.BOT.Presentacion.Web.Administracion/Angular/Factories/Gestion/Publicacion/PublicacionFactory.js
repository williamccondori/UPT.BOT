(function (module) {
    PublicacionFactory.$inject = [
        'BaseFactory'
    ];
    function PublicacionFactory(BaseFactory) {
        var Publicacion = [];
        Publicacion.ObtenerPublicacion = function () {
            return BaseFactory.Obtener('/Gestion/ObtenerPublicacion');
        };
        Publicacion.GuardarPublicacion = function (modelo) {
            return BaseFactory.Guardar('/Gestion/GuardarPublicacion', modelo);
        };
        Publicacion.EliminarPublicacion = function (modelo) {
            return BaseFactory.Eliminar('/Gestion/EliminarPublicacion', modelo);
        };
        return Publicacion;
    }
    module.factory('PublicacionFactory', PublicacionFactory);
})(angular.module("uptbot"));