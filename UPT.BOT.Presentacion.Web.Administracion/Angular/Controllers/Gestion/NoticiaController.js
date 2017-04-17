﻿(function (module) {

    NoticiaController.$inject = ["$scope", "NoticiaFactory"];

    function NoticiaController($scope, NoticiaFactory) {

        $scope.ListaNoticia = [];

        $scope.ResetNoticia = function () {
            $scope.Noticia = {
                DescripcionTitulo: "",
                DescripcionResumen: "",
                DescripcionImagen: "",
                DescripcionUrl: "",
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        }

        $scope.Iniciar = function () {
            $scope.ResetNoticia();
            $scope.ObtenerNoticia();
        };

        $scope.AbrirModalNoticiaAgregar = function () {
            $scope.ResetNoticia();
            $scope.Noticia.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal(Modal.Noticia);
        };

        $scope.AbrirModalNoticiaModificar = function (Noticia) {
            $scope.ResetNoticia();
            $scope.Noticia = Noticia;
            $scope.Noticia.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal(Modal.Noticia);
        };

        $scope.CerrarModalNoticia = function () {
            Bootstrap.CerrarModal(Modal.Noticia);
        };

        $scope.GuardarNoticia = function () {
            NoticiaFactory.GuardarNoticia($scope.Noticia).$promise.then(function (RespuestaApi) {
                if (RespuestaApi.Estado) {
                    Bootstrap.CerrarModal(Modal.Noticia);
                    alert("Correcto!");
                    $scope.ObtenerNoticia();
                } else {
                    Bootstrap.CerrarModal(Modal.Noticia);
                    alert(RespuestaApi.Mensaje);
                }
            });
        };

        $scope.ObtenerNoticia = function () {
            NoticiaFactory.ObtenerNoticia().$promise.then(function (RespuestaApi) {
                if (RespuestaApi.Estado)
                {
                    $scope.ListaNoticia = RespuestaApi.Datos;
                } else {
                    alert(RespuestaApi.Mensaje);
                }
            });
        };
    }

    module.controller("NoticiaController", NoticiaController);

})(angular.module("uptAdministracion"));

var Modal = {
    Noticia: "#ModalNoticia"
}
