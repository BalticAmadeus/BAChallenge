(function() {

    'use strict';

    angular
        .module('EventsApp')
        .factory('UserFactory', UserFactory);

    UserFactory.$inject = ['$http', '$q', 'AuthTokenFactory'];

    // handle API URL

    function UserFactory($http, $q, AuthTokenFactory) {

        return {
            login: login,
            logout: logout,
            getUser: getUser
        };

        function login(username, password) {
            var formData = {
                grant_type: 'password',
                username: username,
                password: password
            }

            return $http({
                    method: "POST",
                    url: 'http://mokymainet.azurewebsites.net/token',
                    // url: 'http://mokymaijava.northeurope.cloudapp.azure.com/api/token',
                    // url: 'http://mokymaijava.northeurope.cloudapp.azure.com/BAChallenge/activity',
                    data: formData,
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    },
                    transformRequest: function(formData) {
                        var str = [];
                        for (var p in formData)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(formData[p]));
                        return str.join("&");
                    },
                })
                .success(function(response) {
                    AuthTokenFactory.setToken(response.access_token);
                    return response;
                });
        }

        function logout() {
            AuthTokenFactory.setToken();
            // vm.user = null;
        }

        function getUser() {
            if (AuthTokenFactory.getToken()) {
                return $http.get('http://mokymainet.azurewebsites.net/token');
                // return $http.get('http://mokymaijava.northeurope.cloudapp.azure.com/api/token');
            } else {
                return $q.reject({ data: 'client has no auth token' });
            }
        }
    };
})();
