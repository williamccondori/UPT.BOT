(function (module) {

    AnalisisController.$inject = ["$scope", "toastr", "AnalisisFactory"];

    function AnalisisController($scope, toastr, AnalisisFactory) {

        $scope.ListaCliente = [];
        $scope.labels = [];
        $scope.data = [];
      
        $scope.Iniciar = function () {
            $scope.ObtenerCliente();
            $scope.ObtenerMensajeXCliente();
        };

        $scope.ObtenerMensajeXCliente = function () {

            AnalisisFactory.ObtenerMensajeXCliente().$promise
                .then(function (RespuestaApi) {

                    debugger;

                    if (RespuestaApi.Estado) {
                        
                        angular.forEach(RespuestaApi.Datos, function (obj) {
                            $scope.labels.push(obj.NombreCliente);
                            $scope.data.push(obj.NumeroMensaje);
                        });
                        
                    } else {
                        toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                    }
                }).catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });

            
        };

        $scope.ObtenerCliente = function () {
            AnalisisFactory.ObtenerCliente().$promise
                .then(function (RespuestaApi) {
                    if (RespuestaApi.Estado) {
                        $scope.ListaCliente = RespuestaApi.Datos;
                    } else {
                        toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                    }
                }).catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });
        };
    }

    module.controller("AnalisisController", AnalisisController);

})(angular.module("uptAdministracion"));

