var app;
(function (app) {
    var controllers;
    (function (controllers) {
        var BaseController = (function () {
            function BaseController() {
            }
            BaseController.inject = ['$scope'];
            return BaseController;
        }());
        controllers.BaseController = BaseController;
    })(controllers = app.controllers || (app.controllers = {}));
})(app || (app = {}));
