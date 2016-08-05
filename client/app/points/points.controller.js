(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('PointsController', PointsController);

    PointsController.$inject = ['$scope', 'dataFactory'];

    function PointsController($scope, dataFactory) {

        var vm = this;

        vm.participants = [];

        dataFactory.getParticipants()
            .then(function(participant) {
                vm.participant = participant.data;
                console.log(participant.data);
            }, function(error) {
                vm.status = 'Unable to load customer data: ' + error.message;
            });

    };
})();
