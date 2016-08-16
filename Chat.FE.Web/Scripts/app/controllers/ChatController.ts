module app.controllers {
    export interface IChatController {
    }

    export interface IChatScope extends ng.IScope {

    }

    export class ChatController extends BaseController implements IChatController {
        registerEvents(): void {
        }
    }

    angular.module('app').controller('ChatController', ChatController);
}