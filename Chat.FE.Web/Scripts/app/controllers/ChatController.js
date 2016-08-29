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
                self = this;
                self._chatProxy = $.connection.chatHub;
                self._chatProxy.client.NewMessageRecived = function (message, login) { return _this.newMessageRecived(message, login); };
                var self = this;
                this.$scope.messages = [];
                this.$scope.renderedMessages = "";
                this.$scope.broadcastMessage = function (message) { return _this.sendMessage(message); };
                this.$scope.$on(app.events.RoomsEvents.RoomChanged, function (event, room, login) {
                    //info dla innych userów, ze dolaczyl nowy - broadcast
                });
            }
            ChatController.prototype.sendMessage = function (message) {
                this._chatProxy.server.broadcastMessage(message, this.$scope.room);
                this.$scope.message = "";
            };
            ChatController.prototype.newMessageRecived = function (message, login) {
                var msg = login + " " + message + "\n";
                this.$scope.messages.push(msg);
                this.$scope.renderedMessages += msg;
                this.$scope.$apply();
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
//# sourceMappingURL=ChatController.js.map