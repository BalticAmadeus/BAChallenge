// (function() {

//     'use strict';

//     angular
//         .module('EventsApp')
//         .controller('adminPointsController', adminPointsController);

//     adminPointsController.$inject = ['dataFactory'];

//     function adminPointsController(dataFactory) {

//         var vm = this;

//         vm.activitiesParticipants = [];



//         dataFactory.getActivitiesParticipants()
//             .then(function(activitiesParticipants) {
//                 vm.activitiesParticipants = activitiesParticipants.data;
//             }, function(error) {
//                 vm.status = 'Unable to load customer data: ' + error.message;
//             });



//     };
// })();
