(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('PointsController', PointsController);

    PointsController.$inject = ['$scope', 'dataFactory'];

    function PointsController($scope, dataFactory) {

        var vm = this;
        vm.total = total;

        vm.activities = [];
        vm.participants = [];
        vm.activitiesParticipants = [];

        dataFactory.getParticipants()
            .then(function(participants) {
                vm.participants = participants.data;
            }, function(error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

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
            console.log(participant.Results.length);
            for (var i = 0; i < participant.Results.length; i++) {
                //console.log(participants.Results[i].Points);
                total += parseInt(participant.Results[i].Points);
            }
            return total;
            // // console.log(participants.data);
        }

    };
})();
