(function() {
    'use strict';
    angular
        .module('EventsApp')
        .controller('AdminCreateModalController', AdminCreateModalController);

    AdminCreateModalController.$inject = ['$scope', '$state', '$uibModalInstance', '$filter', 'ActivityManager'];

    function AdminCreateModalController($scope, $state, $uibModalInstance, $filter, ActivityManager) {

        var vm = this;
        vm.ok = ok;

        vm.newActivityName = '';
        vm.newActivityBranch = '';
        vm.newActivitytDate = '';
        vm.eventHours = '';
        vm.eventMinutes = '';
        vm.newActivityDescription = '';
        vm.newActivityRegistrationDate = '';
        vm.eventRegistrationHours = '';
        vm.eventRegistrationMinutes = '';
        vm.newActivityLocation = '';
        vm.newActivityRegistrationUrl = '';


        vm.activity = $scope.$resolve.activity;


        function ok() {
            $uibModalInstance.dismiss();
        };

        vm.onSubmit = function() {
            // var user = UserService.getUser();
            //console.log('onSubmit');
            if ($scope.userForm.$valid) {
                if (!!vm.newActivitytDate) {
                    var eventDate = $filter('date')(new Date(vm.newActivitytDate), 'yyyy-MM-dd');
                    var filteredEventDate = eventDate + ' ' + vm.eventHours + ':' + vm.eventMinutes;
                } else {
                    filteredEventDate = '';
                }
                if (!!vm.newActivityRegistrationDate) {
                    var eventRegistrationDate = $filter('date')(new Date(vm.newActivityRegistrationDate), 'yyyy-MM-dd');
                    var filteredEventRegistrationDate = eventRegistrationDate + ' ' + vm.eventRegistrationHours + ':' + vm.eventRegistrationMinutes;
                }
                else {
                    filteredEventRegistrationDate = '';
                }

                ActivityManager.createProject(vm.newActivityName,
                        vm.newActivityBranch, filteredEventDate, vm.newActivityDescription,
                        filteredEventRegistrationDate, vm.newActivityLocation, vm.newActivityRegistrationUrl)
                    .then(function(response) {
                        $uibModalInstance.dismiss();
                        $state.reload();
                        //EventDispatcher.triggerEvent('user:accessedEditorView');
                        ///////console.log(response.data);
                        //$state.go('main.container.editor.layout', {id: response.data.id});
                    });
            }
        };

        $scope.popup2 = {
            opened: false
        };

        $scope.open2 = function() {
            $scope.popup2.opened = true;
        };

        $scope.popup1 = {
            opened: false
        };

        $scope.open1 = function() {
            $scope.popup1.opened = true;
        };


        $scope.submitForm = function(isValid) {

            // check to make sure the form is completely valid
            if (isValid) {
                alert('our form is amazing');
            }
        }
    };
})();
