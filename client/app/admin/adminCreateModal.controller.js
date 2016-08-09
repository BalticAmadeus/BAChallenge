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
        vm.newActivityLocation = '';
        vm.newActivityRegistrationUrl = '';


        vm.activity = $scope.$resolve.activity;


        function ok() {
            $uibModalInstance.dismiss();
        };

        vm.onSubmit = function() {
            // var user = UserService.getUser();
            //console.log('onSubmit');
            var eventDate = $filter('date')(new Date(vm.newActivitytDate), 'yyyy-MM-dd');
            var filteredEventDate = eventDate + ' ' + vm.eventHours + ':' + vm.eventMinutes;
            console.log(filteredEventDate);

            ActivityManager.createProject(vm.newActivityName,
                    vm.newActivityBranch, filteredEventDate, vm.newActivityDescription,
                    vm.newActivityRegistrationDate, vm.newActivityLocation, vm.newActivityRegistrationUrl)
                .then(function(response) {
                    $uibModalInstance.dismiss();
                    $state.reload();
                    //EventDispatcher.triggerEvent('user:accessedEditorView');
                    ///////console.log(response.data);
                    //$state.go('main.container.editor.layout', {id: response.data.id});
                });
        };
        
        $scope.popup2 = {
            opened: false
        };

        $scope.open2 = function() {
            $scope.popup2.opened = true;
        };



    };
})();
