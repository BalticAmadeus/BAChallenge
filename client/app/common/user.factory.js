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

        // function login(username, password) {

        //     return $http.post('http://mokymaijava.northeurope.cloudapp.azure.com/api/token', {

        //         grant_type: 'password',
        //         username: username,
        //         password: password
        //     }).then(function success(response) {
        //         AuthTokenFactory.setToken(response.data.access_token);
        //         return response;
        //     });
        // }


        function login(username, password) {
            var formData = {
                grant_type: 'password',
                username: username,
                password: password
            }

            $http({
                method: "POST",
                url: 'http://mokymainet.azurewebsites.net/token',
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
            	alert("response");
                // if (response.status == success) {
                   // alert('all okay'); 
                   //AuthTokenFactory.setToken(response.data.access_token);
        		   // return response;
                   console.log(response.access_token);
                   alert('ok');
                // } else {
                //    // alert(data.msg)
                // }

             	console.log(response.access_token)
                AuthTokenFactory.setToken(response.access_token);
        	    return response;
            });
        }

        function logout() {
            AuthTokenFactory.setToken();
            vm.user = null;
        }

        function getUser() {
            if (AuthTokenFactory.getToken()) {
                return $http.get('http://mokymainet.azurewebsites.net/token');
            } else {
                return $q.reject({ data: 'client has no auth token' });
            }
        }
    };
})();
