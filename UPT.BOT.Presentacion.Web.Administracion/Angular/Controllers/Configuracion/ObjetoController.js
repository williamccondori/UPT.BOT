(function (module) {

    ObjetoController.$inject = ["$scope", "toastr", "ObjetoFactory"];

    function ObjetoController($scope, toastr, ObjetoFactory) {

        $scope.ListaObjeto = [];

        $scope.ResetObjeto = function () {
            $scope.Objeto = {
                DescripcionObjeto: '',
                DescripcionControlador: '',
                DescripcionAccion: '',
                IndicadorHabilitado: 'S',
                Estado: EstadoObjeto.SinCambios
            };
        }

        $scope.Iniciar = function () {
            $scope.ResetObjeto();
            $scope.ObtenerObjeto();
        };

        $scope.CrearObjeto = function () {
            $scope.ResetObjeto();
            $scope.Objeto.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#ModalObjeto');
        };

        $scope.ModificarObjeto = function (modelo) {
            $scope.ResetObjeto();
            $scope.Objeto = modelo;
            $scope.Objeto.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#ModalObjeto');
        };

        $scope.CancelarObjeto = function () {
            Bootstrap.CerrarModal('#ModalObjeto');
        };

        $scope.GuardarObjeto = function () {
            ObjetoFactory.GuardarObjeto($scope.Objeto).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerObjeto();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#ModalObjeto');
        };

        $scope.ObtenerObjeto = function () {
            ObjetoFactory.ObtenerObjeto().then(function (response) {
                if (response.Estado)
                    $scope.ListaObjeto = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
    }

    module.controller('ObjetoController', ObjetoController);

})(angular.module('uptbot'));
