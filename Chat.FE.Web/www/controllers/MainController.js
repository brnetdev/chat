var app;
(function (app) {
    var controllers;
    (function (controllers) {
        var MainController = (function () {
            function MainController($scope) {
                this.scope = $scope;
            }
            MainController.$inject = ["$scope"];
            return MainController;
        }());
        controllers.MainController = MainController;
    })(controllers = app.controllers || (app.controllers = {}));
})(app || (app = {}));
//# sourceMappingURL=MainController.js.map