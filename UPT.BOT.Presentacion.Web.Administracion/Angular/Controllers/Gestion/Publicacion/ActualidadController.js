(function (module) {
    ActualidadController.$inject = [
        '$scope',
        'toastr',
        'ActualidadFactory'
    ];
    function ActualidadController($scope, toastr, ActualidadFactory) {
        $scope.ListaActualidad = [];
        $scope.Reset = function () {
            $scope.Modelo = {
                DescripcionTitulo: '',
                DescripcionImagen: '',
                DescripcionResumen: '',
                DescripcionResena: '',
                DescripcionUrl: '',
                IndicadorEstado: 'A',
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        };
        $scope.Iniciar = function () {
            $scope.Reset();
            $scope.ObtenerActualidad();
        };
        $scope.ObtenerActualidad = function () {
            ActualidadFactory.ObtenerActualidad().then(function (response) {
                if (response.Estado)
                    $scope.ListaActualidad = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.Crear = function () {
            $scope.Reset();
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalActualidad');
        };
        $scope.Modificar = function (modelo) {
            $scope.Reset();
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalActualidad');
        };
        $scope.Cancelar = function () {
            Bootstrap.CerrarModal('#modalActualidad');
        };
        $scope.Guardar = function () {
            ActualidadFactory.GuardarActualidad($scope.Modelo).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerActualidad();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#modalActualidad');
        };
        $scope.Imagen = function () {
            document.getElementById('imagen').src = $scope.Modelo.DescripcionImagen;
            Bootstrap.AbrirModal('#modalImagen');
        };
    }
    module.controller('ActualidadController', ActualidadController);
})(angular.module('uptbot'));