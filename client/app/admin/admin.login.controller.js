(function() {

    'use strict';

    angular
        .module('EventsApp')
        .controller('AdminLoginController', AdminLoginController);

    AdminLoginController.$inject = ['$scope' , '$state' , 'UserFactory'];

    function AdminLoginController($scope , $state , UserFactory) {

        var vm = this;
        vm.login = login;
        vm.logout = logout;

        // inicialization

        UserFactory.getUser().then(function success(response) {
            vm.user = response.data;
        })


        function login(username, password) {

            UserFactory.login(username, password)
                .then(function (response) {
                    vm.user = response.data;
                    $state.go('root.admin');
                }, handleError);
        }

        function logout() {
            UserFactory.logout();
        }

        function handleError(response) {
            //alert('Error: ' + response.data);
        }


    };
})();
