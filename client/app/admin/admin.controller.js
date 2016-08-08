(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('AdminController', AdminController);

    AdminController.$inject = ['$scope', '$state', 'dataFactory', 'ModalWindow', 'UserFactory', 'ActivityManager'];

    function AdminController($scope, $state, dataFactory, ModalWindow, UserFactory, ActivityManager) {

        var vm = this;
        vm.openCreateModal = openCreateModal;
        vm.openDeleteModal = openDeleteModal;
        vm.openUpdateModal = openUpdateModal;
        vm.logout = logout;
        vm.addPoints = addPoints;
        vm.deletePoints = deletePoints;
        vm.addNewParticipant = addNewParticipant;
        vm.deleteParticipant = deleteParticipant;

        vm.activities = [];
        vm.participants = [];
        vm.activitiesParticipants = [];

        vm.newParticipantFirstName = '';
        vm.newParticipantLastName = '';
        // vm.points = '';
        // vm.participant.id = '';

        dataFactory.getActivities()
            .then(function(activities) {
                vm.activities = activities.data;
            }, function(error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

        dataFactory.getParticipants()
            .then(function(participants) {
                vm.participants = participants.data;
            }, function(error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

        function getData() {
            dataFactory.getActivitiesParticipants()
                .then(function(activitiesParticipants) {
                    vm.activitiesParticipants = activitiesParticipants.data;
                }, function(error) {
                    vm.status = 'Unable to load customer data: ' + error.message;
                });
        }
        
        getData();

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
        };

        function addPoints(activityId, participantId, points) {
            ActivityManager.setPoints(activityId, participantId, points)
                .then(function(response) {
                    getData();

                });
        };

        function deletePoints(resultId) {
            console.log(resultId);
            ActivityManager.deletePoints(resultId)
                .then(function(response) {
                    getData();
                });
        }

        function addNewParticipant() {
            // console.log(vm.newParticipantFirstName, vm.newParticipantLastName);

            ActivityManager.addParticipant(vm.newParticipantFirstName, vm.newParticipantLastName)
                .then(function(response) {
                    $state.reload();
                });
        };

        function deleteParticipant(participantId) {
            ActivityManager.deleteParticipant(participantId)
                .then(function(response) {
                    $state.reload();
                });
        };
    };
})();
