(function () {

	'use strict';

	angular
		.module('EventsApp')
		.controller('PointsController', PointsController);

	//PointsController.$inject = ['$scope'];

	function PointsController (/*$scope*/) {

		var vm = this;
        // Pakeist i skaityma is duombazes
        vm.people = [
            {"Vardas":"Jonas", "Pavarde":"Jonaitis", "Vieta":"1", "Sport":"2", "Brain":"4", "Games":"4", "Team":"4", "Total":"14"},
            {"Vardas":"Petras", "Pavarde":"Petraitis", "Vieta":"2", "Sport":"2", "Brain":"2", "Games":"2", "Team":"2", "Total":"8"},
            {"Vardas":"Ona", "Pavarde":"Onaitiene", "Vieta":"3", "Sport":"1", "Brain":"1", "Games":"1", "Team":"1", "Total":"4"}
        ];

	};
})();