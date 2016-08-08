(function() {
    'use strict';
    angular
        .module('EventsApp')
        .service('ActivityManager', ActivityManager);

    ActivityManager.$inject = ['$http'];

    function ActivityManager($http) {

        return {
            createProject: createProject,
            deleteProject: deleteProject,
            updateProject : updateProject
        };

        function createProject(name, branch, date, description,
            registrationDate, location, registrationUrl) {
            var requestData = {
                Name: name,
                Branch: branch,
                Date: date,
                Description: description,
                Location: location,
                RegistrationDate: registrationDate,
                RegistrationUrl: registrationUrl
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

        function updateProject(activityID, name, branch, date, description,
            registrationDate, location, registrationUrl) {
            //console.log(activityID);
            //console.log('http://mokymainet.azurewebsites.net/activity/' + activityID);

            var data = {
                Name: name,
                Branch: branch,
                Date: date,
                Description: description,
                Location: location,
                RegistrationDate: registrationDate,
                RegistrationUrl: registrationUrl
            };

            return $http.put('http://mokymainet.azurewebsites.net/activity/' + activityID, data);
            // return $http.delete('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity/' + activityID);
        };
    };
})();
