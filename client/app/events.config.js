(function() {


    'use strict';

    angular
        .module('EventsApp')
        .config(configBlock)
        .run(run)
        .constant('constant', {
            // 'urlBase' : 'http://mokymainet.azurewebsites.net/api'
            'urlBase' : 'http://mokymaijava.northeurope.cloudapp.azure.com/api'
        }),

    configBlock.$inject = ['$httpProvider'];
    run.$inject = ['$rootScope', '$state', 'AuthTokenFactory'];
    // constant.$inject = [];

    function configBlock($httpProvider) {
        $httpProvider.interceptors.push('AuthInterceptor');
    };

    function run($rootScope, $state, AuthTokenFactory) {

        var token = null;

        $rootScope.$on('$stateChangeStart', function(event, toState, toParams, fromState, fromParams) {

            if (toState.name === 'root.admin.events') {
                var token = AuthTokenFactory.getToken();
                if (!!token) {
                    return;
                } else {
                	event.preventDefault();
                    $state.go('root.login');
                }
            }
            if (toState.name === 'root.login') {
                var token = AuthTokenFactory.getToken();
                if (!!token) {
                    event.preventDefault();
                    $state.go('root.admin.events');
                } else {
                	return;
                }
            }
        })
    };

    // function constant(){
    //     'urlBase' : 'http://mokymainet.azurewebsites.net/token';
    //     console.log(urlBase);
    // };

})();
