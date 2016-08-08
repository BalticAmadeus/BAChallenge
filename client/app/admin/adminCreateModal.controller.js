(function () {
	'use strict';
	angular
		.module('EventsApp')
		.controller('AdminCreateModalController', AdminCreateModalController);

	AdminCreateModalController.$inject = ['$scope', '$state', '$uibModalInstance', 'ActivityManager'];

	function AdminCreateModalController($scope, $state, $uibModalInstance, ActivityManager) {

		var vm = this;
		vm.ok = ok;

		vm.newActivityName = '';
		vm.newActivityBranch ='';
		vm.newActivitytDate = '';
		vm.newActivityDescription = '';
		vm.newActivityRegistrationDate = '';
		vm.newActivityLocation = '';
		vm.newActivityRegistrationUrl = '';

		vm.activity = $scope.$resolve.activity;

		function ok() {
			$uibModalInstance.dismiss();
		};

		vm.onSubmit = function () {
			// var user = UserService.getUser();
			//console.log('onSubmit');
			ActivityManager.createProject(vm.newActivityName,
			 vm.newActivityBranch, vm.newActivitytDate, vm.newActivityDescription,
			 vm.newActivityRegistrationDate, vm.newActivityLocation, vm.newActivityRegistrationUrl)
			.then(function (response) {
				$uibModalInstance.dismiss();
				$state.reload();
				//EventDispatcher.triggerEvent('user:accessedEditorView');
				///////console.log(response.data);
				//$state.go('main.container.editor.layout', {id: response.data.id});
			});		
		};
	};
})();