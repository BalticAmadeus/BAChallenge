(function () {
	'use strict';
	angular
		.module('EventsApp')
		.controller('InfoModalController', InfoModalController);

	InfoModalController.$inject = ['$scope', '$uibModalInstance'];

	function InfoModalController($scope, $uibModalInstance) {

		var vm = this;
		vm.ok = ok;

		vm.activity = $scope.$resolve.activity;
		
		function ok() {
			$uibModalInstance.dismiss();
		};
	};
})();