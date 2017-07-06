(function (module) {

    RolFactory.$inject = ['BaseFactory'];

    function RolFactory(BaseFactory) {

        var Rol = [];

        Rol.ObtenerRol = function () {
            return BaseFactory.Obtener('/Configuracion/ObtenerRol');
        };
        Rol.GuardarRol = function (modelo) {
            return BaseFactory.Guardar('/Configuracion/GuardarRol', modelo);
        };
        Rol.EliminarRol = function (modelo) {
            return BaseFactory.Eliminar('/Configuracion/EliminarRol', modelo);
        };

        return Rol;
    }

    module.factory('RolFactory', RolFactory);

})(angular.module("uptbot"));