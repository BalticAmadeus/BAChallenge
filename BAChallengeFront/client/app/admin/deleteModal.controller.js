(function() {
    'use strict';
    angular
        .module('EventsApp')
        .controller('DeleteModalController', DeleteModalController);

    DeleteModalController.$inject = ['$scope', '$state', '$uibModalInstance', 'ActivityManager'];

    function DeleteModalController($scope, $state, $uibModalInstance, ActivityManager) {
        var vm = this;
        vm.cancel = cancel;
        vm.onSubmit = onSubmit;

        vm.activity = $scope.$resolve.activity;

        function onSubmit(activityID) {
            ActivityManager.deleteProject(activityID).then(function(response) {
                $uibModalInstance.dismiss();
                $state.reload();
            })
        };

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        };
    };
})();