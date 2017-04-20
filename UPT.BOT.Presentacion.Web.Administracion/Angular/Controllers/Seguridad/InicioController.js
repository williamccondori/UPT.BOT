(function (module) {

    NoticiaController.$inject = ["$scope"];

    function InicioController($scope) {

        $scope.ResetUsuario = function () {
            $scope.Usuario = {
                DescripcionUsuario: "",
                DescripcionPassword: "",
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        }

        $scope.Iniciar = function () {
            $scope.ResetUsuario();
        };

        $scope.Cancelar = function () {
            $scope.ResetUsuario();
        };
    }

    module.controller("InicioController", InicioController);

})(angular.module("uptAdministracion"));