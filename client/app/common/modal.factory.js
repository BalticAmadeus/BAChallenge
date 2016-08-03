(function () {
	
	'use strict';
	
	angular
		.module('EventsApp')
		.factory('ModalWindow', ModalWindow);

	ModalWindow.$inject = ['$uibModal'];
	function ModalWindow($uibModal) {
		
		return {
			createWindow: createWindow
		};

		function createWindow(activity, templateUrl, modalController) {
			
			var modalInstance;
			
			modalInstance = $uibModal.open({
				animation: true,
				templateUrl: templateUrl,
				controller: modalController,
				controllerAs: 'vm',
				resolve: {
					activity : function(){
						return activity;
					}
				}
			});
			
			return modalInstance.result;
		};
	};
})();