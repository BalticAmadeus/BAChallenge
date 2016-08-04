(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('AdminController', AdminController);

    AdminController.$inject = ['$scope', '$state', 'dataFactory', 'ModalWindow', 'UserFactory'];

    function AdminController($scope, $state, dataFactory, ModalWindow, UserFactory) {

        var vm = this;
        vm.openInfoModal = openInfoModal;
        vm.openDeleteModal = openDeleteModal;
        vm.logout = logout;

        vm.activities = [];

        dataFactory.getCustomers()
            .then(function(activities) {
                vm.activities = activities.data;
                console.log(activities.data);
            }, function(error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

        function openInfoModal(activity) {
            console.log('miau');
            var templateUrl = 'app/admin/adminInfoModal.view.html';
            ModalWindow.createWindow(activity, templateUrl, 'AdminInfoModalController');
        };

        function openDeleteModal(activity) {
            var templateUrl = 'app/admin/deleteModal.view.html';
            ModalWindow.createWindow(activity, templateUrl, 'DeleteModalController');
            // .then(function(response) {
            // if (response.doDelete) {
            //     ProjectManager.deleteProject(activity, vm.user.id);
            //     $state.go('main.container.user', {}, { reload: true });
            // }
        };

        function logout() {
            UserFactory.logout();
            $state.go('root.login');
        }

    };
})();
