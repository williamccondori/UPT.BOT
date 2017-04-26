(function (module) {

    ActualidadController.$inject = ["$scope", "toastr", "ActualidadFactory"];

    function ActualidadController($scope, toastr, ActualidadFactory) {

        $scope.ListaActualidad = [];

        $scope.ResetActualidad = function () {
            $scope.Actualidad = {
                DescripcionNombre: "",
                DescripcionApellido: "",
                DescripcionEmail: "",
                DescripcionActualidad: "",
                DescripcionPassword: "",
                DescripcionPasswordAdicional: "",
                DescripcionImagen: "",
                DescripcionResena: "",
                IndicadorHabilitado: true,
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        }

        $scope.Iniciar = function () {
            $scope.ResetActualidad();
            $scope.ObtenerActualidad();
        };

        $scope.AbrirModalActualidadAgregar = function () {
            $scope.ResetActualidad();
            $scope.Actualidad.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal(Modal.Actualidad);
        };

        $scope.AbrirModalActualidadModificar = function (Actualidad) {
            $scope.ResetActualidad();
            $scope.Actualidad = Actualidad;
            $scope.Actualidad.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal(Modal.Actualidad);
        };

        $scope.CerrarModalActualidad = function () {
            Bootstrap.CerrarModal(Modal.Actualidad);
        };

        $scope.GuardarActualidad = function () {
            Actualidadactory.GuardarActualidad($scope.Actualidad).$promise.then(function (RespuestaApi) {
                if (RespuestaApi.Estado) {
                    Bootstrap.CerrarModal(Modal.Actualidad);
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerActualidad();
                } else {
                    Bootstrap.CerrarModal(Modal.Actualidad);
                    toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                }
            });
        };

        $scope.ObtenerActualidad = function () {
            ActualidadFactory.ObtenerActualidad().$promise.then(function (RespuestaApi) {
                if (RespuestaApi.Estado) {
                    $scope.ListaActualidad = RespuestaApi.Datos;
                } else {
                    toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                }
            });
        };
    }

    module.controller("ActualidadController", ActualidadController);

})(angular.module("uptAdministracion"));

var Modal = {
    Actualidad: "#ModalActualidad"
}

