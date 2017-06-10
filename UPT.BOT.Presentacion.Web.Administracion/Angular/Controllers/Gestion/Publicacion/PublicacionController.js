(function (module) {
    PublicacionController.$inject = [
        '$scope',
        'toastr',
        'PublicacionFactory'
    ];
    function PublicacionController($scope, toastr, PublicacionFactory) {
        $scope.ListaPublicacion = [];
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
            $scope.ObtenerPublicacion();
        };
        $scope.ObtenerPublicacion = function () {
            PublicacionFactory.ObtenerPublicacion().then(function (response) {
                if (response.Estado)
                    $scope.ListaPublicacion = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.Crear = function () {
            $scope.Reset();
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalPublicacion');
        };
        $scope.Modificar = function (modelo) {
            $scope.Reset();
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalPublicacion');
        };
        $scope.Cancelar = function () {
            Bootstrap.CerrarModal('#modalPublicacion');
        };
        $scope.Guardar = function () {
            PublicacionFactory.GuardarPublicacion($scope.Modelo).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerPublicacion();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#modalPublicacion');
        };
        $scope.Imagen = function () {
            document.getElementById('imagen').src = $scope.Modelo.DescripcionImagen;
            Bootstrap.AbrirModal('#modalImagen');
        };
    }
    module.controller('PublicacionController', PublicacionController);
})(angular.module('uptbot'));