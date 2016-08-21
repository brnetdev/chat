module app.controllers {
    export interface IBaseController {        
        registerEvents(): void;
    }

   
    export abstract class BaseController implements IBaseController {
        
        public abstract registerEvents(): void;
        public static inject = ['$scope'];
        constructor() {
           
        }
    }
}