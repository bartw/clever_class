'use strict';

require('angular').module('app')
    .controller('ClassGroupListController', require('./classGroup.list.controller'))
    .controller('ClassGroupEditController', require('./classGroup.edit.controller'))
    .controller('ClassGroupDetailsController', require('./classGroup.details.controller'));
