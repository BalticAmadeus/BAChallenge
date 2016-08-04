(function () {
	'use strict';
	angular
		.module('EventsApp')
		.service('ActivityManager', ActivityManager);

	ActivityManager.$inject = ['$http'];

	function ActivityManager($http) {
		
		return {
			createProject: createProject,
		};
		
		function createProject(name, branch, date, description,
			 registrationDate, status) {
			var requestData = {
				Name: name,
				Branch: branch,
				Date: date,
				Description: description,
				Location: "location", 
				RegistrationDate: registrationDate,
				RegistrationUrl: 'veik pls'
			};	
			return $http.post('http://mokymainet.azurewebsites.net/activity', requestData);
		}
	};
})();