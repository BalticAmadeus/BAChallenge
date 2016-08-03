(function () {
	'use strict';
	angular
		.module('EventsApp')
		.service('dataFactory', dataFactory);

	dataFactory.$inject = ['$http'];

	 function dataFactory($http)  {
    var dataFactory = {};

    dataFactory.getCustomers = function () {
 
        return $http.get('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity');
    };
    return dataFactory;
	}
})();