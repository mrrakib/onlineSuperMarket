/// <reference path="../../../scripts/angular.js" />
/// <reference path="../../ebuy.js" />
eBuy
    .config(function ($locationProvider) {
    $locationProvider.hashPrefix('');
    })

    .config(function ($routeProvider) {
        $routeProvider
            .when('/allProducts', {
                templateUrl: 'allProducts.html',

            })
            .when('/addProducts', {
                templateUrl: 'addProduct.html'
            })
            .when('/allCategory', {
                templateUrl: 'categories.html'
            })
            .when('/addCategory', {
                templateUrl: 'addCategories.html'
            })
            .when('/addSubCategory', {
                templateUrl: 'addSubCategories.html'
            })
            .when('/subcategories', {
                templateUrl: 'subCategories.html'
            })
            .when('/suppliers', {
                templateUrl: 'suppliers.html'
            })
            .when('/addSupplier', {
                templateUrl: 'addSupplier.html'
            })
            .when('/upSupplier', {
                templateUrl: 'editSupplier.html'
            })

            .when('/login', {
                templateUrl: 'admin/view/Login.html'
            })
            .when('/product', {
                templateUrl: 'customer/view/Products.html'
            })
            
            .when('/adminProduct', {
                templateUrl: '../../customer/view/Products.html'
            })

            .when('/home', {
                templateUrl: '../../Index.html'
            })

            .when('/checkout', {
                templateUrl: 'customer/view/checkout.html'
            })

            .when('/pdfPage', {
                templateUrl: 'customer/view/pdfReport.html'
            })

            .when('/orderBill', {
                templateUrl: 'customer/view/orderProduct.html'
            })

            .when('/prodByCat', {
                templateUrl: 'customer/view/prodByCat.html'
            })

            .when('/allOrders', {
                templateUrl: 'allOrders.html'
            })

            //.otherwise({ redirectTo: '/product'})

    })

