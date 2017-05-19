angular.module("uptAdministracion", ["ngResource", "chart.js", "toastr"]);

(function (module) {

    function Fecha() {
        var fecha = /\/Date\(([0-9]*)\)\//;
        return function (x) {
            var m = x.match(fecha);
            if (m) return new Date(parseInt(m[1]));
            else return null;
        };
    }

    module.filter("Fecha", Fecha);

})(angular.module("uptAdministracion"));
