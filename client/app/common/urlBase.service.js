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
            console.log(apiUrl.urlBase);
        };

        function getUrl() {
            console.log(apiUrl.urlBase);
            return apiUrl.urlBase;
        }
    };
})();
