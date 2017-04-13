(function() {
    'use strict';
    angular
        .module('EventsApp')
        .controller('InfoModalController', InfoModalController);

    InfoModalController.$inject = ['$scope', '$uibModalInstance', 'dataFactory'];

    function InfoModalController($scope, $uibModalInstance, dataFactory) {

        var vm = this;
        vm.ok = ok;

        vm.activityParticipants = [];
        vm.registeredPeople = [];

        vm.activity = $scope.$resolve.activity;

        getActivitiesParticipants();

        function getRegisteredPeople() {
            for (var i = 0; i < vm.activityParticipants.length; i++) {
                if (vm.activityParticipants[i].Activity.ActivityId == vm.activity.ActivityId) {
                    vm.registeredPeople = vm.activityParticipants[i].Participants;
                    break;
                }
            }
        }

        function getActivitiesParticipants() {
            dataFactory.getActivitiesParticipants()
                .then(function(activityParticipants) {
                    vm.activityParticipants = activityParticipants.data;
                    getRegisteredPeople();
                }, function(error) {
                    vm.status = 'Unable to load customer data: ' + error.message;
                });
        };

        function ok() {
            $uibModalInstance.dismiss();
        };
    };
})();
