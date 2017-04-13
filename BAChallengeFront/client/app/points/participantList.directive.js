(function() {
    'use strict';

    angular
        .module('EventsApp')
        .directive('participantListDir', participantListDir);

    function participantListDir() {

    	var directive = {
    		templateUrl: 'app/points/views/participantListDirective.html',
    		link: linkFunc,
    		scope: {
    			participants: '=',
                activityName: '='
    		}
    	}

    	return directive ; 

    	function linkFunc(scope, element, attrs){

            scope.active = false;

            var list = element[0].querySelector('.participant-list-container');

            element.bind('click', function(){
                scope.active = !scope.active;
                scope.$apply();
            })
    		
    	}


    	
    }

})();