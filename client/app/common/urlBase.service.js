(function() {

    'use strict';

    angular
        .module('EventsApp')
        .factory('UrlBase', UrlBase);

    UrlBase.$inject = [];

    function UrlBase() {

        return {
            setUrl: setUrl,
            getUrl: getUrl
        };

        var urlBase;

        function setUrl(url) {
            urlBase = url;
        };

        function getUrl() {
            if (urlBase == null) {
                urlBase = 'http://mokymaijava.northeurope.cloudapp.azure.com/api';
                // urlBase = 'http://mokymainet.azurewebsites.net/api';
                // 'urlBase': 'http://mokymaijava.northeurope.cloudapp.azure.com/BAChallenge'
                return urlBase;
            } else {
                return urlBase;
            }
        }
    };
})();
