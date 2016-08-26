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
            function ChatController($scope) {
                var _this = this;
                _super.call(this);
                this.$scope = $scope;
                self._chatProxy = $.connection.chatHub;
                self._chatProxy.client.newMessageRecived = function (message, login) { return _this.newMessageRecived(message, login); };
                var self = this;
                this.$scope.messages = [];
                this.$scope.broadcastMessage = function (message) { return _this.sendMessage(message); };
            }
            ChatController.prototype.sendMessage = function (message) {
                this._chatProxy.server.broadcastMessage(message, this.$scope.room);
                this.$scope.message = "";
            };
            ChatController.prototype.newMessageRecived = function (message, login) {
                this.$scope.messages.push(login + ": " + message);
            };
            ChatController.prototype.registerEvents = function () {
            };
            ChatController.$inject = ['$scope'];
            return ChatController;
        }(controllers.BaseController));
        controllers.ChatController = ChatController;
        angular.module('app').controller('ChatController', ChatController);
    })(controllers = app.controllers || (app.controllers = {}));
})(app || (app = {}));
