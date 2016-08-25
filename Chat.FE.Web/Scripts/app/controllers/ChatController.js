var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var app;
(function (app) {
    var controllers;
    (function (controllers) {
        var ChatController = (function (_super) {
            __extends(ChatController, _super);
            function ChatController() {
                _super.apply(this, arguments);
            }
            ChatController.prototype.sendMessage = function (message) {
            };
            ChatController.prototype.registerEvents = function () {
            };
            return ChatController;
        }(controllers.BaseController));
        controllers.ChatController = ChatController;
        angular.module('app').controller('ChatController', ChatController);
    })(controllers = app.controllers || (app.controllers = {}));
})(app || (app = {}));
//# sourceMappingURL=ChatController.js.map