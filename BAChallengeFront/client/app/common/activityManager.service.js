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
            registerParticipant : registerParticipant,
            deleteRegisteredPerson : deleteRegisteredPerson,
            editParticipantInformation : editParticipantInformation
        };

        function createProject(name, branch, date, description, goal,
            registrationDate, location, registrationUrl) {
            var requestData = {
                Name: name,
                Branch: branch,
                Date: date,
                Description: description,
                Goal: goal,
                Location: location,
                RegistrationDate: registrationDate,
                RegistrationUrl: registrationUrl
            };

            return $http.post(UrlBase.getUrl() + '/activity', requestData);
        };

        function deleteProject(activityID) {

            return $http.delete(UrlBase.getUrl() + '/activity/' + activityID);
        };

        function updateProject(activityID, name, branch, date, description, goal,
            registrationDate, location, registrationUrl) {

            var data = {
                Name: name,
                Branch: branch,
                Date: date,
                Description: description,
                Goal: goal,
                Location: location,
                RegistrationDate: registrationDate,
                RegistrationUrl: registrationUrl
            };

            return $http.put(UrlBase.getUrl() + '/activity/' + activityID, data);
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

        function deleteRegisteredPerson(participantId, activityId){
            return $http.delete(UrlBase.getUrl() + '/activityparticipant/'+activityId +'/'+ participantId);
        };

        function editParticipantInformation(participantId, activityId, information){
            var data = {
                Information : information
            };
            return $http.put(UrlBase.getUrl() + '/activityparticipant/'+activityId +'/'+ participantId, data);
        };
    };
})();
