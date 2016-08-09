(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('PointsController', PointsController);

    PointsController.$inject = ['$scope', '$filter', 'dataFactory'];

    function PointsController($scope, $filter, dataFactory) {

        var vm = this;
        vm.total = total;

        vm.activities = [];
        vm.participants = [];
        vm.activitiesParticipants = [];

        vm.newObject = {
            activities: [],
            participants: []
        };

        getParticipants();

        function getParticipants() {
            return dataFactory.getParticipants()
                .then(function(participants) {
                    vm.participants = participants.data;
                    // cal();
                    vm.newObject = cal();
                    return vm.participants;
                }, function(error) {
                    vm.status = 'Unable to load customer data: ' + error.message;
                });
        }


        dataFactory.getActivities()
            .then(function(activities) {
                vm.activities = activities.data;
            }, function(error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

        dataFactory.getActivitiesParticipants()
            .then(function(activitiesParticipants) {
                vm.activitiesParticipants = activitiesParticipants.data;
            }, function(error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

        function total(participant) {
            var total = 0;
            for (var i = 0; i < participant.Results.length; i++) {
                total += parseInt(participant.Results[i].Points);
            }
            return total;
        }

        var participantsRow = [];

        function cal() {
            // participantsRow.push(vm.participants);
            // console.log(participantsRow);

            var newObject = {
                activities: [],
                participants: []
            };

            for (var i = 0; i < vm.participants.length; i++) {
                var participant = vm.participants[i];
                for (var j = 0; j < participant.Results.length; j++) {
                    var result = participant.Results[j];
                    // var originalActivitiesName = newObject.activities[j].name;
                    // if(newObject.activities.indexOf(item) == -1) {
                    var found = newObject.activities.some(function(element) {
                        return element.name === result.Activity.Name;
                    });
                    if (!found) {
                        newObject.activities.push({
                            activityId: result.Activity.ActivityId,
                            name: result.Activity.Name
                        });
                    }
                }
            }

            for (var i = 0; i < vm.participants.length; i++) {
                var participant = vm.participants[i];
                var participantobj = {
                    participantId: participant.ParticipantId,
                    participantName: participant.FirstName + ' ' + participant.LastName
                };

                newObject.participants.push(participantobj);
                participantobj.result = [];
                for (var j = 0; j < newObject.activities.length; j++) {
                    var activityId = newObject.activities[j].activityId;
                    var result = participant.Results.find(function(element) {
                        return activityId == element.ActivityId;
                    });
                    if (result === undefined) {
                        participantobj.result.push({
                            points: 0
                        })
                    } else {
                        participantobj.result.push({
                            points: result.Points
                        })
                    }
                }
            }

            return newObject;
        }

    };
})();
