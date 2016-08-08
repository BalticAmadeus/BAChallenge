(function() {
    'use strict';
    angular
        .module('EventsApp')
        .service('ActivityManager', ActivityManager);

    ActivityManager.$inject = ['$http', 'constant'];

    function ActivityManager($http, constant) {

        return {
            createProject: createProject,
            deleteProject: deleteProject,
            updateProject : updateProject,
            setPoints : setPoints,
            deletePoints : deletePoints
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

            return $http.post(constant.urlBase + '/activity', requestData);
            // return $http.post('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity', requestData);
        };

        function deleteProject(activityID) {
            //console.log(activityID);
            //console.log('http://mokymainet.azurewebsites.net/activity/' + activityID);

            return $http.delete(constant.urlBase + '/activity/' + activityID);
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
                RegistrationUrl: registrationUrl,
                _method : 'PUT'
            };

            return $http.post(constant.urlBase + '/activity/' + activityID, data);
            // return $http.delete('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity/' + activityID);
        };

        function setPoints (activityId, participantId, points){
            var data = {
                ActivityId : activityId,
                ParticipantId : participantId,
                Points : points
            };
            return $http.post(constant.urlBase + '/result', data);
        };

        function deletePoints(resultId){
            var data = {
                ResultId : resultId
            };
            return $http.delete(constant.urlBase + '/result/' + resultId);
        };
    };
})();
