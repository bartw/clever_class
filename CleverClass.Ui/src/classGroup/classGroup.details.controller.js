'use strict';

module.exports = function ClassGroupDetailsController(ClassGroup) {
    var vm = this;

    vm.classGroup = {};

    getClassGroup();

    function getClassGroup() {
        vm.classGroup = ClassGroup.get({ id: 5 });
    }
};
