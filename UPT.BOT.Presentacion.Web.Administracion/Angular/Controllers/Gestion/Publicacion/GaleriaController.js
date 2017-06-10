(function (module) {
    GaleriaController.$inject = [
        '$scope',
        'toastr',
        'GaleriaFactory'
    ];
    function GaleriaController($scope, toastr, GaleriaFactory) {
        $scope.ListaGaleria = [];
        $scope.Reset = function () {
            $scope.Modelo = {
                CodigoGaleria: 0,
                DescripcionTitulo: '',
                DescripcionImagen: '',
                DescripcionResena: '',
                DescripcionUrl: '',
                IndicadorEstado: 'A',
                EstadoObjeto: EstadoObjeto.SinCambios,
                Detalles: []
            };
        };
        $scope.ResetDetalle = function () {
            $scope.Detalle = {
                CodigoDetalleGaleria: 0,
                CodigoGaleria: 0,
                DescripcionTitulo: '',
                DescripcionImagen: '',
                DescripcionResena: '',
                IndicadorHabilitado: 'S',
                IndicadorEstado: 'A',
                IndicadorMostrar: true
            };
        };
        $scope.Iniciar = function () {
            $scope.Reset();
            $scope.ObtenerGaleria();
        };
        $scope.ObtenerGaleria = function () {
            GaleriaFactory.ObtenerGaleria().then(function (response) {
                if (response.Estado)
                    $scope.ListaGaleria = response.Datos;
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.Crear = function () {
            $scope.Reset();
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal('#modalGaleria');
        };
        $scope.Modificar = function (modelo) {
            $scope.Reset();
            $scope.Modelo = modelo;
            $scope.Modelo.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal('#modalGaleria');
        };
        $scope.Cancelar = function () {
            $scope.ObtenerGaleria();
            Bootstrap.CerrarModal('#modalGaleria');
        };
        $scope.Guardar = function () {
            GaleriaFactory.GuardarGaleria($scope.Modelo).then(function (response) {
                if (response.Estado) {
                    toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                    $scope.ObtenerGaleria();
                } else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            });
            Bootstrap.CerrarModal('#modalGaleria');
        };
        $scope.Imagen = function () {
            document.getElementById('imagen').src = $scope.Modelo.DescripcionImagen;
            Bootstrap.AbrirModal('#modalImagen');
        };
        $scope.AgregarDetalle = function () {
            $scope.ResetDetalle();
            $scope.Detalle.EstadoObjeto = EstadoObjeto.Nuevo;
            $scope.Modelo.Detalles.push($scope.Detalle);
        };
        $scope.EliminarDetalle = function (elemento) {
            elemento.EstadoObjeto = EstadoObjeto.Borrado;
            elemento.IndicadorMostrar = false;
        };
    }
    module.controller('GaleriaController', GaleriaController);
})(angular.module('uptbot'));