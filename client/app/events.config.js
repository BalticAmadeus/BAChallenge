(function() {


    'use strict';

    angular
        .module('EventsApp')
        .config(configBlock)
        .run(run);

    configBlock.$inject = ['$httpProvider'];
    run.$inject = ['$rootScope', '$state', 'AuthTokenFactory'];

    function configBlock($httpProvider) {
        $httpProvider.interceptors.push('AuthInterceptor');
    };

    function run($rootScope, $state, AuthTokenFactory) {

        var token = null;

        $rootScope.$on('$stateChangeStart', function(event, toState, toParams, fromState, fromParams) {

            if (toState.name === "root.admin") {
                var token = AuthTokenFactory.getToken();
                if (!!token) {
                    return;
                } else {
                	event.preventDefault();
                    $state.go('root.login');
                }
            }
            if (toState.name === "root.login") {
                var token = AuthTokenFactory.getToken();
                if (!!token) {
                    event.preventDefault();
                    $state.go('root.admin');
                } else {
                	return;
                }
            }
        })



    }

})();
