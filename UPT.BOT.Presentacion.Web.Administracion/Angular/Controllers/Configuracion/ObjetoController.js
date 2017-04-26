(function (module) {

    ObjetoController.$inject = ["$scope", "toastr", "ObjetoFactory"];

    function ObjetoController($scope, toastr, ObjetoFactory) {

        $scope.ListaObjeto = [];

        $scope.ResetObjeto = function () {
            $scope.Objeto = {
                DescripcionObjeto: "",
                DescripcionControlador: "",
                DescripcionAccion: "",
                IndicadorGeneral: false,
                IndicadorHabilitado: true,
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        }

        $scope.Iniciar = function () {
            $scope.ResetObjeto();
            $scope.ObtenerObjeto();
        };

        $scope.AbrirModalObjetoAgregar = function () {
            $scope.ResetObjeto();
            $scope.Objeto.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal(Modal.Objeto);
        };

        $scope.AbrirModalObjetoModificar = function (Objeto) {
            $scope.ResetObjeto();
            $scope.Objeto = Objeto;
            $scope.Objeto.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal(Modal.Objeto);
        };

        $scope.CerrarModalObjeto = function () {
            Bootstrap.CerrarModal(Modal.Objeto);
        };

        $scope.GuardarObjeto = function () {
            ObjetoFactory.GuardarObjeto($scope.Objeto).$promise
                .then(function (RespuestaApi) {
                if (RespuestaApi.Estado) {
                    Bootstrap.CerrarModal(Modal.Objeto);
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerObjeto();
                } else {
                    Bootstrap.CerrarModal(Modal.Objeto);
                    toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                }
                })
                .catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });;
        };

        $scope.ObtenerObjeto = function () {
            ObjetoFactory.ObtenerObjeto().$promise
                .then(function (RespuestaApi) {
                if (RespuestaApi.Estado) {
                    $scope.ListaObjeto = RespuestaApi.Datos;
                } else {
                    toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                }
                })
                .catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });;
        };
    }

    module.controller("ObjetoController", ObjetoController);

})(angular.module("uptAdministracion"));

var Modal = {
    Objeto: "#ModalObjeto"
}

