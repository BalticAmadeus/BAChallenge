(function () {
	'use strict';
	angular
		.module('EventsApp')
		.controller('AdminInfoModalController', AdminInfoModalController);

	AdminInfoModalController.$inject = ['$scope', '$state', '$uibModalInstance', 'ActivityManager'];

	function AdminInfoModalController($scope, $state, $uibModalInstance, ActivityManager) {

		var vm = this;
		vm.ok = ok;

		vm.newActivityName = '';
		vm.newActivityBranch ='';
		vm.newActivitytDate = '';
		vm.newActivityDescription = '';
		vm.newActivityRegistrationDate = '';
		vm.newActivityLocation = '';

		vm.activity = $scope.$resolve.activity;
		
		function ok() {
			$uibModalInstance.dismiss();
		};

		vm.onSubmit = function () {
			// var user = UserService.getUser();
			//console.log('onSubmit');
			ActivityManager.createProject(vm.newActivityName,
			 vm.newActivityBranch, vm.newActivitytDate, vm.newActivityDescription,
			 vm.newActivityRegistrationDate, vm.newActivityLocation)
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