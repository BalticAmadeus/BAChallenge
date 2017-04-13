(function() {
    'use strict';
    angular
        .module('EventsApp')
        .service('dataFactory', dataFactory);

    dataFactory.$inject = ['$http', 'UrlBase'];

    function dataFactory($http, UrlBase) {
        // var dataFactory = {};

        return {
            getActivities: getActivities,
            getParticipants: getParticipants,
            getActivitiesParticipants : getActivitiesParticipants
        };

        function getActivities() {
            return $http.get(UrlBase.getUrl() + '/activity');
        };

        function getParticipants() {
            return $http.get(UrlBase.getUrl() + '/participant');
        };

        function getActivitiesParticipants() {
            return $http.get(UrlBase.getUrl() + '/activityparticipant');
        };
    }
})();


// http://mokymainet.azurewebsites.net/token

// http://mokymaijava.northeurope.cloudapp.azure.com/api/activity

// http://mokymaijava.northeurope.cloudapp.azure.com/BAChallenge/     // java



