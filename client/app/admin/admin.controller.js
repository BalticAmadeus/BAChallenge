(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('AdminController', AdminController);

    AdminController.$inject = ['$scope', 'dataFactory', 'ModalWindow'];

    function AdminController($scope, dataFactory, ModalWindow) {

        var vm = this;
        vm.openInfoModal = openInfoModal;

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

    };
})();
