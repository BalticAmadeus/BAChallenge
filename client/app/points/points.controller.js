(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('PointsController', PointsController);

    PointsController.$inject = ['$scope', '$filter', 'dataFactory'];

    function PointsController($scope, $filter, dataFactory) {

        var vm = this;
        vm.getIndexedParticipants = getIndexedParticipants;

        vm.activities = [];
        vm.participants = [];
        vm.activitiesParticipants = [];

        vm.newObject = [];

        getParticipants();

        function getParticipants() {
            return dataFactory.getParticipants()
                .then(function(participants) {
                    vm.participants = participants.data;
                     vm.newObject = getIndexedParticipants();
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


        function getIndexedParticipants() {
            var indexedParticipants = 0;
            indexedParticipants = vm.participants;
            for (var i = 0; i < indexedParticipants.length; i++) {
                var total = 0;
                if (indexedParticipants[i].Results.length) {
                    for (var j = 0; j < indexedParticipants[i].Results.length; j++) {
                        total += parseInt(indexedParticipants[i].Results[j].Points);
                    }
                }
                Object.defineProperty(indexedParticipants[i], "total", {
                    value: total,
                    writable: true,
                    enumerable: true,
                    configurable: true
                });
            }

            indexedParticipants.sort(function(a, b) {
                return b.total - a.total;
            })

            for (var i=0; i<indexedParticipants.length; i++){
                Object.defineProperty(indexedParticipants[i], "id", {
                    value: i+1,
                    writable: true,
                    enumerable: true,
                    configurable: true
                });
            }
            return indexedParticipants;
        }
    };
})();
