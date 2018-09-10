/// <reference path="../../scripts/angular.js" />
/// <reference path="../ebuy.js" />
eBuy

    .config(function ($locationProvider) {
        $locationProvider.hashPrefix('');
    })


    .config(function ($routeProvider) {
    $routeProvider
        .when('/product', {
            templateUrl: 'customer/view/Products.html'
        })

        .otherwise({ redirectTo: '/product' });
})