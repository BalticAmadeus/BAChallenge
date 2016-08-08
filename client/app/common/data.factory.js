(function() {
    'use strict';
    angular
        .module('EventsApp')
        .service('dataFactory', dataFactory);

    dataFactory.$inject = ['$http', 'constant'];

    function dataFactory($http, constant) {
        // var dataFactory = {};

        return {
            getActivities: getActivities,
            getParticipants: getParticipants,
            getActivitiesParticipants : getActivitiesParticipants
        };

        function getActivities() {
            return $http.get(constant.urlBase + '/activity');
            // return $http.get('http://mokymaijava.northeurope.cloudapp.azure.com/BAChallenge/activity');
            // return $http.get('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity');

        };

        function getParticipants() {
            // return $http.get('http://projectx.16mb.com/participant');
            return $http.get(constant.urlBase + '/participant');
        };

        function getActivitiesParticipants() {
            return $http.get(constant.urlBase + '/activityparticipant');
        };
    }
})();


// http://mokymainet.azurewebsites.net/token

// http://mokymaijava.northeurope.cloudapp.azure.com/api/activity

// http://mokymaijava.northeurope.cloudapp.azure.com/BAChallenge/     // java



///////http://projectx.16mb.com/participant
