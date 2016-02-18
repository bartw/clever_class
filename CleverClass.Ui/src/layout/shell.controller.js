(function () {
    'use strict';

    angular
        .module('app.layout')
        .controller('ShellController', ShellController);

    function ShellController() {
        var vm = this;

        vm.title = "CleverClass";
    };
})();
