module app.directives {
    export class modalDialog implements ng.IDirective {

        restrict: string = 'E';        
        templateUrl = 'modalDialogView.html';
        replace = true;
        transclude = true;
        scope: {
            show: '=',
            title: '@',
            
        };

        constructor() {

        }

        static factory(): ng.IDirectiveFactory {
            const directive = () => new modalDialog();
            directive.$inject = [];
            return directive;
        }
    }

}
