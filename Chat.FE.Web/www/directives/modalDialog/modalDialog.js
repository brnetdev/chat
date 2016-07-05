var app;
(function (app) {
    var directives;
    (function (directives) {
        var modalDialog = (function () {
            function modalDialog() {
                this.restrict = 'E';
                this.templateUrl = 'modalDialogView.html';
                this.replace = true;
                this.transclude = true;
            }
            modalDialog.factory = function () {
                var directive = function () { return new modalDialog(); };
                directive.$inject = [];
                return directive;
            };
            return modalDialog;
        }());
        directives.modalDialog = modalDialog;
    })(directives = app.directives || (app.directives = {}));
})(app || (app = {}));
//# sourceMappingURL=modalDialog.js.map