(function() {

    'use strict';
    angular
        .module('EventsApp')
        .config(createStates);

    createStates.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

    function createStates($stateProvider, $urlRouterProvider, $locationProvider) {

        $locationProvider.html5Mode(true);
        $urlRouterProvider.otherwise('/');


        $stateProvider
            .state('root', {
                url: '/',
                abstract: true,
                views: {
                    '': {
                        templateUrl: 'app/layout/layout.view.html',
                        controller: 'LayoutController',
                        controllerAs: 'vm'
                    },
                    'header@root': {
                        templateUrl: 'app/header/header.view.html',
                        controller: 'HeaderController',
                        controllerAs: 'vm'
                    }
                }
            })
            .state('root.eventsList', {
                url: '',
                templateUrl: 'app/eventsList/eventsList.view.html',
                controller: 'EventListController',
                controllerAs: 'vm'
            })
            .state('root.calendar', {
                url: 'calendar',
                templateUrl: 'app/calendar/calendar.view.html',
                controller: 'CalendarController',
                controllerAs: 'vm'
            })
            .state('root.points', {
                url: 'points',
                templateUrl: 'app/points/points.view.html',
                controller: 'PointsController',
                controllerAs: 'vm'
            })

            .state('root.points.all', {
                url: '/all',
                templateUrl: 'app/points/views/pointsAll.view.html',
                // controller: 'PointsController',
                // controllerAs: 'vm'
            })
            .state('root.points.sports', {
                url: '/sports',
                templateUrl: 'app/points/views/pointsSports.view.html',
                // controller: 'PointsController',
                // controllerAs: 'vm'
            })                      
            .state('root.points.games', {
                url: '/games',
                templateUrl: 'app/points/views/pointsGames.view.html',
                // controller: 'PointsController',
                // controllerAs: 'vm'
            })            
            .state('root.points.brain', {
                url: '/brain',
                templateUrl: 'app/points/views/pointsBrain.view.html',
                // controller: 'PointsController',
                // controllerAs: 'vm'
            })            
            .state('root.points.team', {
                url: '/team',
                templateUrl: 'app/points/views/pointsTeam.view.html',
                // controller: 'PointsController',
                // controllerAs: 'vm'
            })


            .state('root.login', {
                url: 'login',
                templateUrl: 'app/admin/admin.login.view.html',
                controller: 'AdminLoginController',
                controllerAs: 'vm'
            })
            .state('root.admin', {
                url: 'admin',
                templateUrl: 'app/admin/admin.view.html',
                controller: 'AdminController',
                controllerAs: 'vm'
            });
    };

})();
