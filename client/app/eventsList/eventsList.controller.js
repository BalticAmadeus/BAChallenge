(function () {

	'use strict';

	angular
		.module('EventsApp')
		.controller('EventListController', EventListController);

	EventListController.$inject = ['$scope', 'dataFactory'];

	function EventListController ($scope, dataFactory) {

		var vm = this;

        vm.activities = [];

        dataFactory.getCustomers()
            .then(function (activities) {
                vm.activities = activities.data;
                console.log("activities.data")
            }, function (error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

	};
})();