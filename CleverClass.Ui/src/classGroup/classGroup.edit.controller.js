(function () {
    'use strict';

    angular
        .module('app.classGroup')
        .controller('ClassGroupEditController', ClassGroupEditController);

    function ClassGroupEditController(ClassGroup) {
        var vm = this;

        vm.classGroup = {};
        vm.save = saveClassGroup;

        function saveClassGroup() {
            if (vm.classGroup.Id > 0) {
                ClassGroup.update({ id: vm.classGroup.Id }, vm.classGroup)
                    .then(function () {
                        alert("saved");
                        vm.classGroup = {};
                    }).catch(function () {
                        alert("something went wrong");
                    });
            } else {
                ClassGroup.save(vm.classGroup)
                    .then(function () {
                        alert("saved");
                        vm.classGroup = {};
                    }).catch(function () {
                        alert("something went wrong");
                    });
            }
        };
    };
})();
