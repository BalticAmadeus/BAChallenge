(function() {
    'use strict';

    angular
        .module('EventsApp')
        .directive('participantDir', participantDir);

    function participantDir() {

    	var directive = {
    		templateUrl: 'app/points/views/participantDirective.html',
    		link: linkFunc,
    		scope: {
    			participant: '=',
    		}
    	}

    	return directive ; 

    	function linkFunc(scope, element, attrs){
    		
    	}


    	
    }

})();