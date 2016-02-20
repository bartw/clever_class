'use strict';

module.exports = function ClassGroup($resource) {
    return $resource('/api/classgroup/:id',
        null,
        { 'update': { method: 'PUT' } });
}