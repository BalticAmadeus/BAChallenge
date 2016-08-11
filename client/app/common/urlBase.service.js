(function() {

    'use strict';

    angular
        .module('EventsApp')
        .factory('UrlBase', UrlBase);

    UrlBase.$inject = ['apiUrl'];

    function UrlBase(apiUrl) {

        return {
            setUrl: setUrl,
            getUrl: getUrl
        };

        function setUrl(url) {
            apiUrl.urlBase = url;
        };

        function getUrl() {
            return apiUrl.urlBase;
        }
    };
})();
