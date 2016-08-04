(function () {

	'use strict';

	angular
		.module('EventsApp')
		.controller('CalendarController', CalendarController);

	CalendarController.$inject = ['$scope', 'UserFactory'];

	function CalendarController ($scope, UserFactory) {

		var vm = this;
		
	};
})();