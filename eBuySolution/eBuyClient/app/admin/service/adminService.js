/// <reference path="../../../scripts/angular.js" />
/// <reference path="../../ebuy.js" />
eBuy

    //.factory('formDataObject', function () {
    //    return function (data) {
    //        var fd = new FormData();
    //        angular.forEach(data, function (value, key) {
    //            fd.append(key, value);
    //        });
    //        return fd;
    //    };
    //})

    .service('adminSvc', function ($http) {
        //get method for getting all items
        this.get = function (url) {
            return $http({
                method: 'GET',
                url: url
            });
        };

        //post method for add items
        this.postMethod = function (url, data, header) {
            return $http({
                method: 'POST',
                url: url,
                data: data
            });
        };

        //this.addSubCat = function (url, formdata) {
        //    return $http.post(url, formdata, {
        //        transformRequest: angular.identity,
        //        headers: { 'Content-Type': undefined }
        //    })
        //}

        this.put = function (url, id, data) {
            return $http({
                method: 'PUT',
                url: url + '(' + id + ')',
                data: data
            });
        }

        this.delete = function (url, id) {
            return $http({
                method: 'DELETE',
                url: url + '(' + id + ')'
            });
        }

        this.getById = function (url, id) {
            return $http({
                method: 'GET',
                url: url + '(' + id + ')'
            });
        }

    });