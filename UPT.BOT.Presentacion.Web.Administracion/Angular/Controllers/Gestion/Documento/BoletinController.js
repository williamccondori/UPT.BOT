(function (module) {
    BoletinController.$inject = [
        '$scope',
        'toastr',
        'BoletinFactory'
    ];
    function BoletinController($scope, toastr, BoletinFactory) {
        $scope.ListaBoletin = [];
        $scope.Reset = function () {
            $scope.Modelo = {
                CodigoDocumento: 0,
                DescripcionTitulo: '',
                DescripcionResena: '',
                DescripcionBoletin: '',
                DescripcionUrl: '',
                IndicadorEstado: true,
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        };
        $scope.Iniciar = function () {
            $scope.Reset();
            $scope.ObtenerBoletin();
        };
        $scope.ObtenerBoletin = function () {
            BoletinFactory.ObtenerBoletin().then(function (response) {
                if (response.Estado)
                    $scope.ListaBoletin = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.Crear = function () {
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalBoletin');
        };
        $scope.Modificar = function (modelo) {
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalBoletin');
        };
        $scope.Cancelar = function () {
            $scope.Reset();
            Bootstrap.CerrarModal('#modalBoletin');
        };
        $scope.Guardar = function () {
            BoletinFactory.GuardarBoletin($scope.Modelo).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerBoletin();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#modalBoletin');
        };
    }
    module.controller('BoletinController', BoletinController);
})(angular.module('uptbot'));