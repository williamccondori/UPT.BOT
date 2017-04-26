(function (module) {

    UsuarioController.$inject = ["$scope", "toastr", "UsuarioFactory"];

    function UsuarioController($scope, toastr, UsuarioFactory) {

        $scope.ListaUsuario = [];

        $scope.ResetUsuario = function () {
            $scope.Usuario = {
                DescripcionNombre: "",
                DescripcionApellido: "",
                DescripcionEmail: "",
                DescripcionUsuario: "",
                DescripcionPassword: "",
                DescripcionPasswordAdicional: "",
                DescripcionImagen: "",
                DescripcionResena: "",
                IndicadorHabilitado: true,
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        }

        $scope.Iniciar = function () {
            $scope.ResetUsuario();
            $scope.ObtenerUsuario();
        };

        $scope.AbrirModalUsuarioAgregar = function () {
            $scope.ResetUsuario();
            $scope.Usuario.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal(Modal.Usuario);
        };

        $scope.AbrirModalUsuarioModificar = function (Usuario) {
            $scope.ResetUsuario();
            $scope.Usuario = Usuario;
            $scope.Usuario.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal(Modal.Usuario);
        };

        $scope.CerrarModalUsuario = function () {
            Bootstrap.CerrarModal(Modal.Usuario);
        };

        $scope.GuardarUsuario = function () {
            UsuarioFactory.GuardarUsuario($scope.Usuario).$promise
                .then(function (RespuestaApi) {
                    if (RespuestaApi.Estado) {
                        Bootstrap.CerrarModal(Modal.Usuario);
                        toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                        $scope.ObtenerUsuario();
                    } else {
                        Bootstrap.CerrarModal(Modal.Usuario);
                        toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                    }
                }).catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });
        };

        $scope.ObtenerUsuario = function () {
            UsuarioFactory.ObtenerUsuario().$promise
                .then(function (RespuestaApi) {
                    if (RespuestaApi.Estado) {
                        $scope.ListaUsuario = RespuestaApi.Datos;
                    } else {
                        toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                    }
                }).catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });
        };
    }

    module.controller("UsuarioController", UsuarioController);

})(angular.module("uptAdministracion"));

var Modal = {
    Usuario: "#ModalUsuario"
}

