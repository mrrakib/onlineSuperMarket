eBuy

    .service('accSvc', function ($http) {
        var userUrl = "http://localhost:8595/odata/UserDetails/";

        this.signUpUser = function (user) {
            return $http({
                method: 'POST',
                url: userUrl,
                data: user
            });
        }

    })