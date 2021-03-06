(function() {
    'use strict';
    angular
        .module('EventsApp')
        .controller('RegistrationDeleteModal', RegistrationDeleteModal);

    RegistrationDeleteModal.$inject = ['$scope', '$state', '$uibModalInstance', 'ActivityManager'];

    function RegistrationDeleteModal($scope, $state, $uibModalInstance, ActivityManager) {
        var vm = this;
        vm.cancel = cancel;
        vm.deleteRegisteredPeople = deleteRegisteredPeople;

        vm.modalInfo = $scope.$resolve.modalInfo;

        function deleteRegisteredPeople() {
            ActivityManager.deleteRegisteredPerson(vm.modalInfo.participantId, vm.modalInfo.activityId).then(function(response) {
                $uibModalInstance.close();
                $state.reload();
            })
        };

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        };
    };
})();

