(function (module) {
    ComunicadoController.$inject = [
        '$scope',
        'toastr',
        'ComunicadoFactory'
    ];
    function ComunicadoController($scope, toastr, ComunicadoFactory) {
        $scope.ListaComunicado = [];
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
            $scope.ObtenerComunicado();
        };
        $scope.ObtenerComunicado = function () {
            ComunicadoFactory.ObtenerComunicado().then(function (response) {
                if (response.Estado)
                    $scope.ListaComunicado = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.Crear = function () {
            $scope.Reset();
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalComunicado');
        };
        $scope.Modificar = function (modelo) {
            $scope.Reset();
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalComunicado');
        };
        $scope.Cancelar = function () {
            Bootstrap.CerrarModal('#modalComunicado');
        };
        $scope.Guardar = function () {
            ComunicadoFactory.GuardarComunicado($scope.Modelo).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerComunicado();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#modalComunicado');
        };
        $scope.Imagen = function () {
            document.getElementById('imagen').src = $scope.Modelo.DescripcionImagen;
            Bootstrap.AbrirModal('#modalImagen');
        };
    }
    module.controller('ComunicadoController', ComunicadoController);
})(angular.module('uptbot'));