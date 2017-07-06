(function (module) {

    RolController.$inject = ["$scope", "toastr", "RolFactory"];

    function RolesController($scope, toastr, RolFactory) {

        $scope.ListaRol = [];

        $scope.ResetRol = function () {
            $scope.Rol = {
                DescripcionRol: '',
                DescripcionControlador: '',
                DescripcionAccion: '',
                IndicadorHabilitado: 'S',
                Estado: EstadoObjeto.SinCambios
            };
        }

        $scope.Iniciar = function () {
            $scope.ResetRol();
            $scope.ObtenerRol();
        };

        $scope.CrearRol = function () {
            $scope.ResetRol();
            $scope.Rol.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#ModalRol');
        };

        $scope.ModificarRol = function (modelo) {
            $scope.ResetRol();
            $scope.Rol = modelo;
            $scope.Rol.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#ModalRol');
        };

        $scope.CancelarRol = function () {
            Bootstrap.CerrarModal('#ModalRol');
        };

        $scope.GuardarRol = function () {
            RolFactory.GuardarRol($scope.Rol).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerRol();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#ModalRol');
        };

        $scope.ObtenerRol = function () {
            RolFactory.ObtenerRol().then(function (response) {
                if (response.Estado)
                    $scope.ListaRol = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
    }

    module.controller('RolController', RolController);

})(angular.module('uptbot'));
