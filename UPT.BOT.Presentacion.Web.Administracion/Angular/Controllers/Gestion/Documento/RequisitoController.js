(function (module) {
    RequisitoController.$inject = [
        '$scope',
        'toastr',
        'RequisitoFactory'
    ];
    function RequisitoController($scope, toastr, RequisitoFactory) {
        $scope.ListaRequisito = [];
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
            $scope.ObtenerRequisito();
        };
        $scope.ObtenerRequisito = function () {
            RequisitoFactory.ObtenerRequisito().then(function (response) {
                if (response.Estado)
                    $scope.ListaRequisito = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.Crear = function () {
            $scope.Reset();
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalRequisito');
        };
        $scope.Modificar = function (modelo) {
            $scope.Reset();
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalRequisito');
        };
        $scope.Cancelar = function () {
            Bootstrap.CerrarModal('#modalRequisito');
        };
        $scope.Guardar = function () {
            RequisitoFactory.GuardarRequisito($scope.Modelo).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerRequisito();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#modalRequisito');
        };
    }
    module.controller('RequisitoController', RequisitoController);
})(angular.module('uptbot'));