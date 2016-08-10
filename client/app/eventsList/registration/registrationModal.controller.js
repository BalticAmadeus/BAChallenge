(function() {
    'use strict';
    angular
        .module('EventsApp')
        .controller('RegistrationModalController', RegistrationModalController);

    RegistrationModalController.$inject = ['$scope', '$uibModalInstance', 'dataFactory', 'ActivityManager'];

    function RegistrationModalController($scope, $uibModalInstance, dataFactory, ActivityManager) {

        var vm = this;
        vm.register = register;
        vm.cancel = cancel;
        vm.showError = false;
        vm.activity = $scope.$resolve.activity;

        vm.selectedParticipant = '';
        vm.description = '';

        vm.participants = [];
        vm.activityParticipants = [];

        dataFactory.getParticipants()
            .then(function(participants) {
                vm.participants = participants.data;
            }, function(response) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

        function cancel() {
            $uibModalInstance.dismiss();
        };

        function register() {
            ActivityManager.registerParticipant(vm.activity.ActivityId, vm.selectedParticipant.ParticipantId, vm.description)
                .then(function(response) {
                    $uibModalInstance.dismiss();

                }, function(response){
                    if(response.status == 405){
                        vm.showError = true;
                    }
                });
        }
    };
})();
