(function (module) {

    InicioController.$inject = ["$scope"];

    function InicioController($scope) {

        $scope.Usuario = {};

        $scope.Iniciar = function () {
            $scope.ObtenerDatosUsuario();
        };

        $scope.ObtenerDatosUsuario = function () {
            $scope.Usuario = {
                DescripcionNombre: "William",
                DescripcionApellido: "Condori Quispe",
                DescripcionCargo: "Adminsitrador",
                DescripcionImagen: "https://instagram.faqp1-1.fna.fbcdn.net/t51.2885-19/s150x150/17934364_404572093248456_7991878769902092288_a.jpg"
            };
        };
    }

    module.controller("InicioController", InicioController);

})(angular.module("uptAdministracion"));