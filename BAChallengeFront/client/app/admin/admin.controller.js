(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('AdminController', AdminController);

    AdminController.$inject = ['$scope', '$state', '$uibModal', 'dataFactory', 'ModalWindow', 'UserFactory', 'ActivityManager', 'UrlBase'];

    function AdminController($scope, $state, $uibModal, dataFactory, ModalWindow, UserFactory, ActivityManager, UrlBase) {

        var vm = this;
        vm.openCreateModal = openCreateModal;
        vm.openDeleteModal = openDeleteModal;
        vm.openUpdateModal = openUpdateModal;
        vm.logout = logout;
        vm.addPoints = addPoints;
        vm.deletePoints = deletePoints;
        vm.addNewParticipant = addNewParticipant;
        vm.deleteParticipant = deleteParticipant;
        vm.openDeleteRegisteredModal = openDeleteRegisteredModal;
        vm.exportExcel = exportExcel;
        vm.openEditInformationModal = openEditInformationModal;

        vm.activities = [];
        vm.participants = [];
        vm.activitiesParticipants = [];

        vm.newParticipantFirstName = '';
        vm.newParticipantLastName = '';

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

        function addPoints(activityId, participantId, points, description) {
            ActivityManager.setPoints(activityId, participantId, points, description)
                .then(function(response) {
                    getData();

                });
        };

        function deletePoints(resultId) {
            ActivityManager.deletePoints(resultId)
                .then(function(response) {
                    getData();
                });
        }

        function addNewParticipant() {
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

        function openDeleteRegisteredModal(participantId, activityId) {
            var modalInstance;

            var modalInfo = {
                'participantId': participantId,
                'activityId': activityId
            }

            modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'app/admin/adminParticipants/registrationDeleteModal.view.html',
                controller: 'RegistrationDeleteModal',
                controllerAs: 'vm',
                resolve: {
                    modalInfo: function() {
                        return modalInfo;
                    }
                }
            });

            return modalInstance.result;
        };

        function exportExcel(){
            return UrlBase.getUrl();
        };

        function openEditInformationModal(participantId, activityId, information){
            var modalInstance;
            var editInfo = {
                'participantId': participantId,
                'activityId': activityId,
                'information' : information
            }

            modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'app/admin/adminParticipants/editInformationModal.view.html',
                controller: 'EditInformationModal',
                controllerAs: 'vm',
                resolve: {
                    editInfo: function() {
                        return editInfo;
                    }
                }
            });

            modalInstance.result.then(function() {
                getData();
            });
        };
    };
})();
