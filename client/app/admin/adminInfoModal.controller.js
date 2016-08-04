(function () {
	'use strict';
	angular
		.module('EventsApp')
		.controller('AdminInfoModalController', AdminInfoModalController);

	AdminInfoModalController.$inject = ['$scope', '$uibModalInstance', 'ActivityManager'];

	function AdminInfoModalController($scope, $uibModalInstance, ActivityManager) {

		var vm = this;
		vm.ok = ok;

		vm.newActivityName = '';
		vm.newActivityBranch ='';
		vm.newActivitytDate = '';
		vm.newActivityDescription = '';
		vm.newActivityRegistrationDate = '';
		vm.newActivityStatus = '';

		vm.activity = $scope.$resolve.activity;
		
		function ok() {
			$uibModalInstance.dismiss();
		};

		vm.onSubmit = function () {
			// var user = UserService.getUser();
			//console.log('onSubmit');
			ActivityManager.createProject(vm.newActivityName,
			 vm.newActivityBranch, vm.newActivitytDate, vm.newActivityDescription,
			 vm.newActivityRegistrationDate, vm.newActivityStatus)
			.then(function (response) {
				$uibModalInstance.dismiss();
				//EventDispatcher.triggerEvent('user:accessedEditorView');
				///////console.log(response.data);
				//$state.go('main.container.editor.layout', {id: response.data.id});
			});		
		};
	};
})();