// JavaScript Requester with promises

// Dependencies: jQuery and Q.js

var requester = (function () {
    var makeRequest = function (url, method, data, headers) {
        var defer = Q.defer();

        $.ajax({
            url: url,
            method: method,
            contentType: 'application/json',
            data: JSON.stringify(data) || undefined,
            headers: headers,
            success: function(data) {
                defer.resolve(data);
            },
            error: function(error) {
                defer.reject(error);
            }
        });

        return defer.promise;
    }

    var makeGetRequest = function (url, headers) {
        return makeRequest(url, 'GET', null, headers);
    }

    var makePostRequest = function (url, data, headers) {
        return makeRequest(url, 'POST', data, headers);
    }

    var makePutRequest = function (url, data, headers) {
        return makeRequest(url, 'PUT', data, headers);
    }

    var makeDeleteRequest = function (url, headers) {
        return makeRequest(url, 'DELETE', null, headers);
    }


    return {
        get: makeGetRequest,
        post: makePostRequest,
        put: makePutRequest,
        delete: makeDeleteRequest
    }
}());