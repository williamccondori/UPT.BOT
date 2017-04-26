(function (module) {

    RolController.$inject = ["$scope", "toastr", "RolFactory"];

    function RolController($scope, toastr, RolFactory) {

        $scope.ListaRol = [];

        $scope.ResetRol = function () {
            $scope.Rol = {
                DescripcionRol: "",
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        }

        $scope.Iniciar = function () {
            $scope.ResetRol();
            $scope.ObtenerRol();
        };

        $scope.AbrirModalRolAgregar = function () {
            $scope.ResetRol();
            $scope.Rol.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal(Modal.Rol);
        };

        $scope.AbrirModalRolModificar = function (Rol) {
            $scope.ResetRol();
            $scope.Rol = Rol;
            $scope.Rol.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal(Modal.Rol);
        };

        $scope.CerrarModalRol = function () {
            Bootstrap.CerrarModal(Modal.Rol);
        };

        $scope.GuardarRol = function () {
            RolFactory.GuardarRol($scope.Rol).$promise
                .then(function (RespuestaApi) {
                    if (RespuestaApi.Estado) {
                        Bootstrap.CerrarModal(Modal.Rol);
                        toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                        $scope.ObtenerRol();
                    } else {
                        Bootstrap.CerrarModal(Modal.Rol);
                        toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                    }
                })
                .catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });
        };

        $scope.ObtenerRol = function () {
            RolFactory.ObtenerRol().$promise.then(function (RespuestaApi) {
                if (RespuestaApi.Estado) {
                    $scope.ListaRol = RespuestaApi.Datos;
                } else {
                    toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                }
            })
                .catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });;
        };
    }

    module.controller("RolController", RolController);

})(angular.module("uptAdministracion"));

var Modal = {
    Rol: "#ModalRol"
}

