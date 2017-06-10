(function (module) {
    EventoController.$inject = [
        '$scope',
        'toastr',
        'EventoFactory'
    ];
    function EventoController($scope, toastr, EventoFactory) {
        $scope.ListaEvento = [];
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
            $scope.ObtenerEvento();
        };
        $scope.ObtenerEvento = function () {
            EventoFactory.ObtenerEvento().then(function (response) {                                    
                if (response.Estado)
                    $scope.ListaEvento = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.Crear = function () {
            $scope.Reset();
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalEvento');
        };
        $scope.Modificar = function (modelo) {
            $scope.Reset();
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalEvento');
        };
        $scope.Cancelar = function () {
            Bootstrap.CerrarModal('#modalEvento');
        };
        $scope.Guardar = function () {
            EventoFactory.GuardarEvento($scope.Modelo).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerEvento();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#modalEvento');
        };
        $scope.Imagen = function () {
            document.getElementById('imagen').src = $scope.Modelo.DescripcionImagen;
            Bootstrap.AbrirModal('#modalImagen');
        };
    }
    module.controller('EventoController', EventoController);
})(angular.module('uptbot'));