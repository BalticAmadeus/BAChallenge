(function() {
    'use strict';
    angular
        .module('EventsApp')
        .service('dataFactory', dataFactory);

    dataFactory.$inject = ['$http'];

    function dataFactory($http) {
        var dataFactory = {};

        dataFactory.getCustomers = function() {

            return $http.get('http://mokymainet.azurewebsites.net/activity');
            // return $http.get('http://mokymaijava.northeurope.cloudapp.azure.com/BAChallenge/activity');
            // return $http.get('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity');

        };

        dataFactory.getParticipants = function() {

        	return $http.get('http://projectx.16mb.com/participant');
        };


        return dataFactory;
    }
})();


// http://mokymainet.azurewebsites.net/token

// http://mokymaijava.northeurope.cloudapp.azure.com/api/activity

// http://mokymaijava.northeurope.cloudapp.azure.com/BAChallenge/     // java



///////http://projectx.16mb.com/participant