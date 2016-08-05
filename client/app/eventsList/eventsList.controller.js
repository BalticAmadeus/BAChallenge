(function () {

	'use strict';

	angular
		.module('EventsApp')
		.controller('EventListController', EventListController);

	EventListController.$inject = ['$scope', 'dataFactory', 'ModalWindow'];

	function EventListController ($scope, dataFactory, ModalWindow) {

		var vm = this;
		vm.openInfoModal = openInfoModal;

        vm.activities = [];

        dataFactory.getCustomers()
            .then(function (activities) {
                vm.activities = activities.data;
                console.log(activities.data);
            }, function (error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

            function openInfoModal(activity) {
			var templateUrl = 'app/eventsList/infoModal.view.html';
			ModalWindow.createWindow(activity, templateUrl, 'InfoModalController');
		};

	};
})();