(function() {
    'use strict';
    angular
        .module('EventsApp')
        .service('ActivityManager', ActivityManager);

    ActivityManager.$inject = ['$http'];

    function ActivityManager($http) {

        return {
            createProject: createProject,
            deleteProject : deleteProject
        };

        function createProject(name, branch, date, description,
            registrationDate, status) {
            var requestData = {
                Name: name,
                Branch: branch,
                Date: date,
                Description: description,
                Location: "location",
                RegistrationDate: registrationDate,
                RegistrationUrl: 'veik pls'
            };

            return $http.post('http://mokymainet.azurewebsites.net/activity', requestData);
            // return $http.post('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity', requestData);
        };

        function deleteProject(activityID) {
        	//console.log(activityID);
        	//console.log('http://mokymainet.azurewebsites.net/activity/' + activityID);
            
            return $http.delete('http://mokymainet.azurewebsites.net/activity/' + activityID);
            // return $http.delete('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity/' + activityID);
        };
    };
})();
