(function() {
    'use strict';
    angular
        .module('EventsApp')
        .controller('AdminUpdateModalController', AdminUpdateModalController);

    AdminUpdateModalController.$inject = ['$scope', '$state', '$uibModalInstance', 'ActivityManager'];

    function AdminUpdateModalController($scope, $state, $uibModalInstance, ActivityManager) {

        var vm = this;
        vm.ok = ok;

        vm.activity = $scope.$resolve.activity;

        vm.activityName = vm.activity.Name;
        vm.activityBranch = vm.activity.Branch;
        vm.activitytDate = vm.activity.Date;
        vm.activityDescription = vm.activity.Description;
        vm.activityGoal = vm.activity.Goal;
        vm.activityRegistrationDate = vm.activity.RegistrationDate;
        vm.activityLocation = vm.activity.Location;
        vm.activityRegistrationUrl = vm.activity.RegistrationUrl;

        function ok() {
            $uibModalInstance.dismiss();
        };

        vm.onSubmit = function(activityID) {
            ActivityManager.updateProject(activityID, vm.activityName,
                    vm.activityBranch, vm.activitytDate, vm.activityDescription, vm.activityGoal,
                    vm.activityRegistrationDate, vm.activityLocation, vm.activityRegistrationUrl)
                .then(function(response) {
                    $uibModalInstance.dismiss();
                    $state.reload();
                });
        };
    };
})();
