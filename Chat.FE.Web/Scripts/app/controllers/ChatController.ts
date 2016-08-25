module app.controllers {
    export interface IChatController {
        sendMessage(message: string): void;
    }

    export interface IChatScope extends ng.IScope {
        messages: string[];
    }

    export class ChatController extends BaseController implements IChatController {
        public sendMessage(message: string): void {
                        
        }
        registerEvents(): void {
        }
    }

    angular.module('app').controller('ChatController', ChatController);
}