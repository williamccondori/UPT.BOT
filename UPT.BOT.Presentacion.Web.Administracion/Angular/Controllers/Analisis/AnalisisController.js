(function (module) {
    AnalisisController.$inject = [
        '$scope',
        'toastr',
        'AnalisisFactory'
    ];
    function AnalisisController($scope, toastr, AnalisisFactory) {
        $scope.ListaCliente = [];
        $scope.grafico01 = {
            Datos: [],
            Etiquetas: []
        };
        $scope.grafico02 = {
            Datos: [],
            Etiquetas: []
        };
        $scope.grafico03 = {
            Datos: [],
            Etiquetas: []
        };
        $scope.Iniciar = function () {
            $scope.ObtenerCliente();
            $scope.ObtenerMensajeXCliente();
            $scope.ObtenerResumenMes();
            $scope.ObtenerResumenIntenciones();
        };
        $scope.ObtenerMensajeXCliente = function () {
            AnalisisFactory.ObtenerMensajeXCliente().then(function (response) {
                if (response.Estado)
                {
                    angular.forEach(response.Datos, function (elemento) {
                        $scope.grafico01.Etiquetas.push(elemento.Etiqueta);
                        $scope.grafico01.Datos.push(elemento.Valor);
                    });
                }
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.ObtenerResumenMes = function () {
            AnalisisFactory.ObtenerResumenMes().then(function (response) {
                if (response.Estado) {
                    angular.forEach(response.Datos, function (elemento) {
                        $scope.grafico02.Etiquetas.push(elemento.Etiqueta);
                        $scope.grafico02.Datos.push(elemento.Valor);
                    });
                }
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.ObtenerResumenIntenciones = function () {
            AnalisisFactory.ObtenerResumenIntenciones().then(function (response) {
                if (response.Estado) {
                    angular.forEach(response.Datos, function (elemento) {
                        $scope.grafico03.Etiquetas.push(elemento.Etiqueta);
                        $scope.grafico03.Datos.push(elemento.Valor);
                    });
                }
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
        $scope.ObtenerCliente = function () {
            AnalisisFactory.ObtenerCliente().then(function (response) {
                if (response.Estado)
                {
                    $scope.ListaCliente = response.Datos;
                } 
                else
                    toastr.error(response.Mensaje, Mensaje.Error.Titulo);
            }).catch(function (error) {
                toastr.error(MensajeRespuesta.Error, Mensaje.Error.Titulo);
            });
        };
    }
    module.controller('AnalisisController', AnalisisController);
})(angular.module('uptbot'));
