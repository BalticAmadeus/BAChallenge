(function () {
	'use strict';
	angular
		.module('EventsApp')
		.controller('AdminInfoModalController', AdminInfoModalController);

	AdminInfoModalController.$inject = ['$scope', '$uibModalInstance'];

	function AdminInfoModalController($scope, $uibModalInstance) {

		var vm = this;
		vm.ok = ok;

		vm.activity = $scope.$resolve.activity;
		
		function ok() {
			$uibModalInstance.dismiss();
		};
	};
})();