(function () {

	'use strict';

	angular
		.module('EventsApp')
		.controller('EventsListController', EventsListController);

	EventsListController.$inject = ['$scope'];

	function EventsListController ($scope) {

		var vm = this;

	};
})();