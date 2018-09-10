var eBuy;
(function () {
    eBuy = angular.module('eBuy', ['ngRoute', 'ngCookies', 'angularUtils.directives.dirPagination'])
        .config(function ($httpProvider) {
            var interceptor = function ($cookies, $q, $window) {
                return {
                    request: function (config) {
                        var access_token = $cookies.utoken;
                        if (access_token != null) {
                            config.headers['Authorization'] = 'Bearer ' + access_token;
                        }
                        return config;
                    },
                    responseError: function (rejection) {
                        if (rejection.status === 401 || rejection.status === 403) {
                            $window.location.href = "/app/index.html";
                            return $q.reject(rejection);
                        }
                        return $q.reject(rejection);
                    }
                }
            }
            var params = ['$cookies', '$q', '$window'];
            interceptor.$inject = params;
            $httpProvider.interceptors.push(interceptor);
        })

})();