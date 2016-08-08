(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('AdminController', AdminController);

    AdminController.$inject = ['$scope', '$state', 'dataFactory', 'ModalWindow', 'UserFactory'];

    function AdminController($scope, $state, dataFactory, ModalWindow, UserFactory) {

        var vm = this;
        vm.openCreateModal = openCreateModal;
        vm.openDeleteModal = openDeleteModal;
        vm.openUpdateModal = openUpdateModal;
        vm.logout = logout;

        vm.activities = [];

        dataFactory.getActivities()
            .then(function(activities) {
                vm.activities = activities.data;
                console.log(activities.data);
            }, function(error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

        function openCreateModal(activity) {
            var templateUrl = 'app/admin/adminCreateModal.view.html';
            ModalWindow.createWindow(activity, templateUrl, 'AdminCreateModalController');
        };

        function openDeleteModal(activity) {
            var templateUrl = 'app/admin/deleteModal.view.html';
            ModalWindow.createWindow(activity, templateUrl, 'DeleteModalController');
        };

        function openUpdateModal(activity) {
            var templateUrl = 'app/admin/adminUpdateModal.view.html';
            ModalWindow.createWindow(activity, templateUrl, 'AdminUpdateModalController');
        };

        function logout() {
            UserFactory.logout();
            $state.go('root.login');
        }

    };
})();
