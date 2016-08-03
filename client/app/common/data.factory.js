(function () {
	'use strict';
	angular
		.module('EventsApp')
		.service('dataFactory', dataFactory);

	dataFactory.$inject = ['$http'];

	 function dataFactory($http)  {
	//var urlBase = '/api/activity';
    var dataFactory = {};

    dataFactory.getCustomers = function () {
 
        return $http.get('http://mokymainet.azurewebsites.net/api/activity');
        			// .then(function(response){
        			// 	return response.data;
        			// });
    };
    return dataFactory;
	}
})();