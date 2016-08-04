(function () {

	'use strict';

	angular
		.module('EventsApp')
		.controller('CalendarController', CalendarController);

	CalendarController.$inject = ['$scope', 'UserFactory'];

	function CalendarController ($scope, UserFactory) {

		var vm = this;
		vm.login = login;
		vm.logout = logout;

		// inicialization

		UserFactory.getUser().then(function success(response) {
			vm.user = response.data;
		})


		function login(username, password){
			UserFactory.login(username, password)
						.then(function success(response){
							vm.user = response.data;
							alert(response.data.token);
						}, handleError);
		}

		function logout() { 
			UserFactory.logout();
		}

		function handleError(response){
			//alert('Error: ' + response.data);
		}
	};
})();