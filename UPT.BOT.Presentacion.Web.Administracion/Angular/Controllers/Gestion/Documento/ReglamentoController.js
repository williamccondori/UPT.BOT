(function (module) {
    ReglamentoController.$inject = [
        '$scope',
        'toastr',
        'ReglamentoFactory'
    ];
    function ReglamentoController($scope, toastr, ReglamentoFactory) {
        $scope.ListaReglamento = [];
        $scope.Reset = function () {
            $scope.Modelo = {
                CodigoDocumento: 0,
                DescripcionTitulo: '',
                DescripcionResena: '',
                DescripcionReglamento: '',
                DescripcionUrl: '',
                IndicadorEstado: true,
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        };
        $scope.Iniciar = function () {
            $scope.Reset();
            $scope.ObtenerReglamento();
        };
        $scope.ObtenerReglamento = function () {
            ReglamentoFactory.ObtenerReglamento().then(function (response) {
                if (response.Estado)
                    $scope.ListaReglamento = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.Crear = function () {
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalReglamento');
        };
        $scope.Modificar = function (modelo) {
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalReglamento');
        };
        $scope.Cancelar = function () {
            $scope.Reset();
            Bootstrap.CerrarModal('#modalReglamento');
        };
        $scope.Guardar = function () {
            ReglamentoFactory.GuardarReglamento($scope.Modelo).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerReglamento();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#modalReglamento');
        };
    }
    module.controller('ReglamentoController', ReglamentoController);
})(angular.module('uptbot'));