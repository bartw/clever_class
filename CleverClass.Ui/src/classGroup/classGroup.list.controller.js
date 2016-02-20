'use strict';

module.exports = function ClassGroupListController(ClassGroup) {
    var vm = this;

    vm.classGroups = [];
    vm.delete = deleteClassGroup;

    getClassGroups();

    function getClassGroups() {
        vm.classGroups = ClassGroup.query();
    }

    function deleteClassGroup(id) {
        ClassGroup.delete({ id: id })
            .then(function () {
                alert("deleted");
            }).catch(function () {
                alert("something went wrong");
            });
    }
};
