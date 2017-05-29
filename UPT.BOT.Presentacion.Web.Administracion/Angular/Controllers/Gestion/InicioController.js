(function (module) {

    InicioController.$inject = [
        '$scope'
    ];

    function InicioController($scope) {

        $scope.MostrarInformacion = function () {
            $scope.Ocultar();
            $scope.Informacion = true;
        }

        $scope.MostrarPublicacion = function () {
            $scope.Ocultar();
            $scope.Publicacion = true;
        }

        $scope.MostrarDocumento = function () {
            $scope.Ocultar();
            $scope.Documento = true;
        }

        $scope.Ocultar = function () {
            $scope.Informacion = false;
            $scope.Publicacion = false;
            $scope.Planestudio = false;
            $scope.Documento = false;
            $scope.Intencion = false;
            $scope.Extra = false;
        }

    }

    module.controller("InicioController", InicioController);

})(angular.module("uptAdministracion"));