(function() {
    'use strict';
    angular
        .module('EventsApp')
        .service('ActivityManager', ActivityManager);

    ActivityManager.$inject = ['$http', 'UrlBase'];

    function ActivityManager($http, UrlBase) {

        return {
            createProject: createProject,
            deleteProject: deleteProject,
            updateProject : updateProject,
            setPoints : setPoints,
            deletePoints : deletePoints,
            addParticipant : addParticipant,
            deleteParticipant : deleteParticipant,
            registerParticipant : registerParticipant
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

            return $http.post(UrlBase.getUrl() + '/activity', requestData);
            // return $http.post('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity', requestData);
        };

        function deleteProject(activityID) {
            //console.log(activityID);
            //console.log('http://mokymainet.azurewebsites.net/activity/' + activityID);

            return $http.delete(UrlBase.getUrl() + '/activity/' + activityID);
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
                // _method : 'PUT'
            };

            return $http.put(UrlBase.getUrl() + '/activity/' + activityID, data);
            // return $http.delete('http://mokymaijava.northeurope.cloudapp.azure.com/api/activity/' + activityID);
        };

        function setPoints (activityId, participantId, points, description){
            var data = {
                ActivityId : activityId,
                ParticipantId : participantId,
                Points : points,
                Description : description
            };
            return $http.post(UrlBase.getUrl() + '/result', data);
        };

        function deletePoints(resultId){
            var data = {
                ResultId : resultId
            };
            return $http.delete(UrlBase.getUrl() + '/result/' + resultId);
        };

        function addParticipant(newParticipantFirstName, newParticipantLastName){
            var data = {
                FirstName : newParticipantFirstName,
                LastName : newParticipantLastName
            };
            return $http.post(UrlBase.getUrl() + '/participant', data)
        };

        function deleteParticipant(participantId){
            var data = {
                ParticipantId : participantId
            };
            return $http.delete(UrlBase.getUrl() + '/participant/' + participantId);
        };

        function registerParticipant(activityId, participantId, description){
            var data = {
                ActivityId : activityId,
                ParticipantId : participantId,
                Information : description    
            };
            return $http.post(UrlBase.getUrl() + '/activityparticipant/', data);
        }
    };
})();
