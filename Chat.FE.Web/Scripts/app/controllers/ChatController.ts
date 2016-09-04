module app.controllers {
    export interface IChatController {
        sendMessage(message: string): void;
        newMessageRecived(message: string, login: string);
        showDialog(user: string);
    }

    export interface IChatScope extends ng.IScope {
        room: string;
        messages: string[];    
        renderedMessages: string;    
        message: string;
        broadcastMessage(message: string): void;
    }

    export class ChatController extends BaseController implements IChatController {
        private _chatProxy: IChatHubProxy;

        public static $inject = ['$scope'];
        constructor(private $scope: IChatScope) {
            super();
            self = this;
            self._chatProxy = $.connection.chatHub;
            self._chatProxy.client.NewMessageRecived = (message: string, login: string) => this.newMessageRecived(message, login);            
            var self = this;

            this.$scope.messages = [];
            this.$scope.renderedMessages = "";
            this.$scope.broadcastMessage = (message: string) => this.sendMessage(message);

            this.$scope.$on(app.events.RoomsEvents.RoomChanged, (event, room, login) => {
                //info dla innych userów, ze dolaczyl nowy - broadcast

            });

            
            
        }
        public sendMessage(message: string): void {                        
            this._chatProxy.server.broadcastMessage(message, this.$scope.room);
            this.$scope.message = "";
        }

        public newMessageRecived(message: string, login: string): void {            
            var msg = login + " " + message + "\n";
            this.$scope.messages.push(msg);
            this.$scope.renderedMessages += msg;                        
            this.$scope.$apply();
        }

        public showDialog(user: string): void {
            
        }

        registerEvents(): void {

        }
    }

    angular.module('app').controller('ChatController', ChatController);
}