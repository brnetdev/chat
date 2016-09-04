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
        link = function (scope: any, element: any, attrs: any, controller: any) {
            if (scope.show) {
                element.showModal();
            }
        }

        constructor() {

        }

        static factory(): ng.IDirectiveFactory {
            const directive = () => new modalDialog();
            directive.$inject = [];
            return directive;
        }
    }

}
