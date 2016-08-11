(function() {
    'use strict';
    angular
        .module('EventsApp')
        .controller('EditInformationModal', EditInformationModal);

    EditInformationModal.$inject = ['$scope', '$state', '$uibModalInstance', 'ActivityManager'];

    function EditInformationModal($scope, $state, $uibModalInstance, ActivityManager) {
        var vm = this;
        vm.cancel = cancel;
        vm.editInformation = editInformation;

        vm.editInfo = $scope.$resolve.editInfo;

        console.log(vm.editInfo);

        function editInformation() {
            console.log(vm.editInfo.information);

            ActivityManager.editParticipantInformation(vm.editInfo.participantId, vm.editInfo.activityId, vm.editInfo.information).then(function(response) {
                $uibModalInstance.dismiss();
                // $state.reload();
                // getData();
            })
        };

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        };

    };
})();

//
