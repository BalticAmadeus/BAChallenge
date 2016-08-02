(function () {

	'use strict';

	angular
		.module('EventsApp')
		.controller('CalendarController', CalendarController);

	CalendarController.$inject = ['$scope'];

	function CalendarController ($scope) {

		var vm = this;

	};
})();