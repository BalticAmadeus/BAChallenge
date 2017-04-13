(function() {
    'use strict';

    angular
        .module('EventsApp')
        .directive('pointsDir', pointsDir);

    function pointsDir() {

    	var directive = {
    		templateUrl: 'app/points/views/pointsDirective.html',
    		link: linkFunc,
    		scope: {
    			activityArray: '=',
    			activityType: '@'
    		}
    	}

    	return directive ; 

    	function linkFunc(scope, element, attrs){
    		
    	}


    	
    }

})();