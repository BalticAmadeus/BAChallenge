(function () {
	
	'use strict';
	
	angular
		.module('EventsApp')
		.factory('UserFactory', UserFactory);

	UserFactory.$inject = ['$http','$q','AuthTokenFactory'];

	// handle API URL

	function UserFactory($http, $q, AuthTokenFactory) {
		
		return{
			login : login,
			logout : logout,
			getUser : getUser
		};

		function login(username, password){
			
			return $http.post('http://mokymaijava.northeurope.cloudapp.azure.com/api/token', {

				grant_type : 'password',
				username : username,
				password : password
			}).then(function success(response){
				AuthTokenFactory.setToken(response.data.access_token);
				return response;
			});
		}

		function logout() {
			AuthTokenFactory.setToken();
			vm.user = null;
		}

		function getUser(){
			if (AuthTokenFactory.getToken()){
				return $http.get('http://mokymaijava.northeurope.cloudapp.azure.com/api/token');
			} else{
				return $q.reject({ data: 'client has no auth token'});
			}
		}
	};
})();