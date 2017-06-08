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
                DescripcionFormato: '',
                DescripcionUrl: '',
                IndicadorEstado: 'A',
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
            $scope.Reset();
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalReglamento');
        };
        $scope.Modificar = function (modelo) {
            $scope.Reset();
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalReglamento');
        };
        $scope.Cancelar = function () {
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