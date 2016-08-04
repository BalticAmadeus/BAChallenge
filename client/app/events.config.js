(function () {
	
	'use strict';

	angular
		.module('EventsApp')
		.config(configBlock);
	
	configBlock.$inject = ['$httpProvider'];
	
	function configBlock ($httpProvider) {
		$httpProvider.interceptors.push('AuthInterceptor');
	};
	
})();