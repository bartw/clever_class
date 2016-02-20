(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('ClassGroup', ClassGroup);

    function ClassGroup($resource) {

        return $resource('/api/classgroup/:id',
            null,
            { 'update': { method: 'PUT' } });

        //var service = {
        //    getClassGroups: getClassGroups
        //};

        //return service;

        //function getClassGroups() {
        //    return $http.get('/api/classgroup')
        //        .then(getClassGroupsComplete)
        //        .catch(function (message) {
        //        });

        //    function getClassGroupsComplete(data, status, headers, config) {
        //        return data.data;
        //    }
        //}

        //function getClassGroup(id) {
        //    return $http.get('/api/classgroup')
        //        .then(getClassGroupsComplete)
        //        .catch(function (message) {
        //        });

        //    function getClassGroupsComplete(data, status, headers, config) {
        //        return data.data;
        //    }
        //}
    }
})();

