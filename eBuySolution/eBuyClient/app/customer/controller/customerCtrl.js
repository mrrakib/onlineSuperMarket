/// <reference path="../../../scripts/angular.js" />
/// <reference path="../../ebuy.js" />
eBuy
    .controller('customerCtrl', function ($scope, $window, $location) {
        $scope.LoginPage = function () {
            $window.location.href = '/app/admin/view/Login.html';
        }
    })