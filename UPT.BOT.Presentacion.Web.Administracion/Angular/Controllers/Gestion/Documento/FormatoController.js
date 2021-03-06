(function (module) {
    FormatoController.$inject = [
        '$scope',
        'toastr',
        'FormatoFactory'
    ];
    function FormatoController($scope, toastr, FormatoFactory) {
        $scope.ListaFormato = [];
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
            $scope.ObtenerFormato();
        };
        $scope.ObtenerFormato = function () {
            FormatoFactory.ObtenerFormato().then(function (response) {
                if (response.Estado)
                    $scope.ListaFormato = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.Crear = function () {
            $scope.Reset();
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalFormato');
        };
        $scope.Modificar = function (modelo) {
            $scope.Reset();
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalFormato');
        };
        $scope.Cancelar = function () {
            Bootstrap.CerrarModal('#modalFormato');
        };
        $scope.Guardar = function () {
            FormatoFactory.GuardarFormato($scope.Modelo).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerFormato();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#modalFormato');
        };
    }
    module.controller('FormatoController', FormatoController);
})(angular.module('uptbot'));