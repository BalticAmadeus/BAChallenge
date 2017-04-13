(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('EventListController', EventListController);

    EventListController.$inject = ['$scope', '$filter', 'dataFactory', 'ModalWindow', 'UrlBase', 'UserFactory'];

    function EventListController($scope, $filter, dataFactory, ModalWindow, UrlBase, UserFactory) {

        var vm = this;
        vm.openInfoModal = openInfoModal;
        vm.openRegistrationModal = openRegistrationModal;
        vm.switchToPhp = switchToPhp;
        vm.switchToNet = switchToNet;
        vm.switchToJava = switchToJava;
        vm.isEventPast = isEventPast;
        vm.checkApi = checkApi;

        vm.activities = [];

        function getActivitiesData() {
            dataFactory.getActivities()
                .then(function(activities) {
                    vm.activities = activities.data;
                }, function(error) {
                    vm.status = 'Unable to load customer data: ' + error.message;
                });
        };

        getActivitiesData();

        function openRegistrationModal(activity) {
            var templateUrl = 'app/eventsList/Registration/registrationModal.view.html';
            ModalWindow.createWindow(activity, templateUrl, 'RegistrationModalController');
        };

        function openInfoModal(activity) {
            var templateUrl = 'app/eventsList/infoModal.view.html';
            ModalWindow.createWindow(activity, templateUrl, 'InfoModalController');
        };

        function switchToPhp() {
            // var url = 'http://mokymaijava.northeurope.cloudapp.azure.com/api';
            UserFactory.logout();
            var url = 'http://mokymaijava.northeurope.cloudapp.azure.com/api';
            UrlBase.setUrl(url);
            getActivitiesData();
        };

        function switchToNet() {
            // var url = 'http://mokymaijava.northeurope.cloudapp.azure.com/api';
            UserFactory.logout();
            var url = 'http://mokymainet.azurewebsites.net/api';
            UrlBase.setUrl(url);
            getActivitiesData();
        };

        function switchToJava() {
            // var url = 'http://mokymaijava.northeurope.cloudapp.azure.com/api';
            var url = 'http://mokymaijava.northeurope.cloudapp.azure.com/BAChallenge';
            UserFactory.logout();
            UrlBase.setUrl(url);
            getActivitiesData();
        };

        isEventPast();

        function isEventPast(eventDate){
            var now = new Date();
            var formattedNow =  $filter('date')(new Date(now), 'yyyy-MM-dd');
            return formattedNow > eventDate;
        }

        function checkApi(url){
            if(url === UrlBase.getUrl()){
                return true;
            }
        }


    };
})();
