(function () {

	'use strict';

	angular
		.module('EventsApp')
		.controller('HeaderController', HeaderController);

	HeaderController.$inject = ['$scope'];

	function HeaderController ($scope) {

		var vm = this;

	};
})();