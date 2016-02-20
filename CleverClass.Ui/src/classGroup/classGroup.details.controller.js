(function () {
    'use strict';

    angular
        .module('app.classGroup')
        .controller('ClassGroupDetailsController', ClassGroupDetailsController);

    function ClassGroupDetailsController(ClassGroup) {
        var vm = this;

        vm.classGroup = {};

        getClassGroup();

        function getClassGroup() {
            vm.classGroup = ClassGroup.get({ id: 5 });
        }
    };
})();
